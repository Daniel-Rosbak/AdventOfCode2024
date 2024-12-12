namespace AdventOfCode2024;

public class Day12 : Day
{
    public override string Run()
    {
        return PartTwo();
    }

    private string PartOne()
    {
        Console.WriteLine("input: ");
        List<char[]> input = new List<char[]>();
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            input.Add(next.ToCharArray());
            next = Console.ReadLine();
        }
        
        int res = 0;
        
        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[0].Length; j++)
            {
                if (input[i][j] != '.')
                {
                    List<string> region = new List<string>();
                    
                    res += FindRegionAndFence(input, region, new []{j, i}, input[i][j]) * region.Count;
                }
            }
        }
        
        return "Answer for part 1: " + res;
    }

    private int FindRegionAndFence(List<char[]> field, List<string> region, int[] pos, char type)
    {
        int count = 0;
        if (field[pos[1]][pos[0]] == type)
        {
            region.Add(pos[0] + " " + pos[1]);
            field[pos[1]][pos[0]] = '.';
            if (pos[0] > 0)
            {
                count += FindRegionAndFence(field, region, new []{pos[0] - 1, pos[1]}, type);
            }
            else
            {
                count += 1;
            }
            if (pos[1] > 0)
            {
                count += FindRegionAndFence(field, region, new []{pos[0], pos[1] - 1}, type);
            }
            else
            {
                count += 1;
            }
            if (pos[0] < field[0].Length - 1)
            {
                count += FindRegionAndFence(field, region, new []{pos[0] + 1, pos[1]}, type);
            }
            else
            {
                count += 1;
            }
            if (pos[1] < field.Count - 1)
            {
                count += FindRegionAndFence(field, region, new []{pos[0], pos[1] + 1}, type);
            }
            else
            {
                count += 1;
            }
        }
        else if (!region.Contains(pos[0] + " " + pos[1]))
        {
            count = 1;
        }

        return count;
    }

    private string PartTwo()
    {
        Console.WriteLine("input: ");
        List<char[]> input = new List<char[]>();
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            input.Add(next.ToCharArray());
            next = Console.ReadLine();
        }
        
        int res = 0;
        
        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[0].Length; j++)
            {
                if (input[i][j] != '.')
                {
                    List<string> region = new List<string>();
                    
                    res += FindDiscountedFence(input, region, new []{j, i}, input[i][j]) * region.Count;
                }
            }
        }

        return "Answer for part 2: " + res;
    }

    private int FindDiscountedFence(List<char[]> field, List<string> region, int[] pos, char type)
    {
        int count = FindRegionAndDiscountedFence(field, region, pos, type);
        
        for (int i = 0; i < region.Count; i++)
        {
            string[] plot = region[i].Split(" ");
            field[int.Parse(plot[1])][int.Parse(plot[0])] = '.';
        }

        return count;
    }
    
    private int FindRegionAndDiscountedFence(List<char[]> field, List<string> region, int[] pos, char type)
    {
        int count = 0;
        string here = pos[0] + " " + pos[1];
        if (field[pos[1]][pos[0]] == type)
        {
            region.Add(here);
            
            //check new squares
            if (pos[0] > 0 && !region.Contains((pos[0] - 1) + " " + pos[1]))
            {
                count += FindRegionAndDiscountedFence(field, region, new []{pos[0] - 1, pos[1]}, type);
            }
            if (pos[1] > 0 && !region.Contains(pos[0] + " " + (pos[1] - 1)))
            {
                count += FindRegionAndDiscountedFence(field, region, new []{pos[0], pos[1] - 1}, type);
            }
            if (pos[0] < field[0].Length - 1 && !region.Contains((pos[0] + 1) + " " + pos[1]))
            {
                count += FindRegionAndDiscountedFence(field, region, new []{pos[0] + 1, pos[1]}, type);
            }
            if (pos[1] < field.Count - 1 && !region.Contains(pos[0] + " " + (pos[1] + 1)))
            {
                count += FindRegionAndDiscountedFence(field, region, new []{pos[0], pos[1] + 1}, type);
            }
            //check if corner
            Char[,] neighbor = new char[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int y = pos[1] - 1 + i, x = pos[0] - 1 + j;
                    if (y < field.Count && y >= 0 && x < field[0].Length && x >= 0)
                    {
                        neighbor[i, j] = (field[y][x] == type || field[y][x] == ':')? ':' : '.';
                    }
                    else
                    {
                        neighbor[i, j] = '.';
                    }
                }
            }

            bool inCorner = neighbor[1 , 0] == ':' && neighbor[0, 1] == ':' && neighbor[0, 0] != ':';
            bool corner = neighbor[1, 0] != ':' && neighbor[0, 1] != ':';
            if (inCorner || corner)
            {
                count++;
            }
            inCorner = neighbor[1 , 2] == ':' && neighbor[0, 1] == ':' && neighbor[0, 2] != ':';
            corner = neighbor[1, 2] != ':' && neighbor[0, 1] != ':';
            if (inCorner || corner)
            {
                count++;
            }
            inCorner = neighbor[1 , 2] == ':' && neighbor[2, 1] == ':' && neighbor[2, 2] != ':';
            corner = neighbor[1, 2] != ':' && neighbor[2, 1] != ':';
            if (inCorner || corner)
            {
                count++;
            }
            inCorner = neighbor[1 , 0] == ':' && neighbor[2, 1] == ':' && neighbor[2, 0] != ':';
            corner = neighbor[1, 0] != ':' && neighbor[2, 1] != ':';
            if (inCorner || corner)
            {
                count++;
            }
        }
        
        return count;
    }
}