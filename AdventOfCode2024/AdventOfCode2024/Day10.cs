namespace AdventOfCode2024;

public class Day10 : Day
{
    public override string Run()
    {
        return PartTwo();
    }
    
    private string PartOne()
    {
        Console.WriteLine("input: ");
        List<string> input = new List<string>();
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            input.Add(next);
            next = Console.ReadLine();
        }

        List<List<int>> map = new List<List<int>>();

        for (int i = 0; i < input.Count; i++)
        {
            List<int> line = new List<int>();
            for (int j = 0; j < input[i].Length; j++)
            {
                line.Add(int.Parse(input[i][j].ToString()));
            }
            map.Add(line);
        }

        int res = 0;
        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map[i].Count; j++)
            {
                if (map[i][j] == 0)
                {
                    found = new List<int[]>();
                    FindTrailhead(map, j, i, 1);
                    res += found.Count;
                    Console.WriteLine("");
                }
            }
        }
        
        return "Answer for part 1: " + res;
    }

    private List<int[]> found;
    
    private void FindTrailhead(List<List<int>> map, int x, int y, int next)
    {
        int up = (y > 0)? map[y - 1][x] : next - 1;
        int down = (y < map.Count - 1)? map[y + 1][x] : next - 1;
        int left = (x > 0)? map[y][x - 1] : next - 1;
        int right = (x < map[0].Count - 1)? map[y][x + 1] : next - 1;

        if (next == 9)
        {
            if (up == next)
            {
                int[] xy = { x, y - 1 };
                if (!Exists(xy[0], xy[1]))
                {
                    found.Add(xy);
                    Console.WriteLine(xy[0] + " " + xy[1]);
                }
            }
            if (down == next)
            {
                int[] xy = { x, y + 1 };
                if (!Exists(xy[0], xy[1]))
                {
                    found.Add(xy);
                    Console.WriteLine(xy[0] + " " + xy[1]);
                }
            }
            if (left == next)
            {
                int[] xy = { x - 1, y };
                if (!Exists(xy[0], xy[1]))
                {
                    found.Add(xy);
                    Console.WriteLine(xy[0] + " " + xy[1]);
                }
            }
            if (right == next)
            {
                int[] xy = { x + 1, y };
                if (!Exists(xy[0], xy[1]))
                {
                    found.Add(xy);
                    Console.WriteLine(xy[0] + " " + xy[1]);
                }
            }
        }
        else
        {
            if (up == next)
            {
                FindTrailhead(map, x, y - 1, next + 1);
            }
            if (down == next)
            {
                FindTrailhead(map, x, y + 1, next + 1);
            }
            if (left == next)
            {
                FindTrailhead(map, x - 1, y, next + 1);
            }
            if (right == next)
            {
                FindTrailhead(map, x + 1, y, next + 1);
            }
        }
    }

    private bool Exists(int x, int y)
    {
        bool exists = false;
        for (int i = 0; i < found.Count; i++)
        {
            if (found[i][0] == x && found[i][1] == y)
            {
                exists = true;
            }
        }

        return exists;
    }

    private string PartTwo()
    {
        Console.WriteLine("input: ");
        List<string> input = new List<string>();
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            input.Add(next);
            next = Console.ReadLine();
        }

        List<List<int>> map = new List<List<int>>();

        for (int i = 0; i < input.Count; i++)
        {
            List<int> line = new List<int>();
            for (int j = 0; j < input[i].Length; j++)
            {
                line.Add(int.Parse(input[i][j].ToString()));
            }
            map.Add(line);
        }

        int res = 0;
        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map[i].Count; j++)
            {
                if (map[i][j] == 0)
                {
                    res += FindTrailRating(map, j, i, 1);
                }
            }
        }
        
        return "Answer for part 2: " + res;
    }
    
    private int FindTrailRating(List<List<int>> map, int x, int y, int next)
    {
        int up = (y > 0)? map[y - 1][x] : next - 1;
        int down = (y < map.Count - 1)? map[y + 1][x] : next - 1;
        int left = (x > 0)? map[y][x - 1] : next - 1;
        int right = (x < map[0].Count - 1)? map[y][x + 1] : next - 1;
        int res = 0;

        if (next == 9)
        {
            if (up == next)
            {
                res += 1;
            }
            if (down == next)
            {
                res += 1;
            }
            if (left == next)
            {
                res += 1;
            }
            if (right == next)
            {
                res += 1;
            }
        }
        else
        {
            if (up == next)
            {
                res += FindTrailRating(map, x, y - 1, next + 1);
            }
            if (down == next)
            {
                res += FindTrailRating(map, x, y + 1, next + 1);
            }
            if (left == next)
            {
                res += FindTrailRating(map, x - 1, y, next + 1);
            }
            if (right == next)
            {
                res += FindTrailRating(map, x + 1, y, next + 1);
            }
        }

        return res;
    }
}