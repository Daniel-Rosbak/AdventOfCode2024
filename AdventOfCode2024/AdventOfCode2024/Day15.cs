namespace AdventOfCode2024;

public class Day15 : Day
{
    public override string Run()
    {
        return PartTwo();
    }
    
    private string PartOne()
    {
        Console.WriteLine("input: ");
        List<char[]> map = new List<char[]>();
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            map.Add(next.ToCharArray());
            next = Console.ReadLine();
        }

        string moves = "";
        next = Console.ReadLine();
        while (next != String.Empty)
        {
            moves += next;
            next = Console.ReadLine();
        }

        int x = 0, y = 0;
        bool found = false;
        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map[0].Length; j++)
            {
                if (map[i][j] == '@')
                {
                    x = j;
                    y = i;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                break;
            }
        }

        int difX, difY;
        
        for (int i = 0; i < moves.Length; i++)
        {
            switch (moves[i])
            {
                case '^':
                    difY = -1;
                    difX = 0;
                    break;
                case '>':
                    difY = 0;
                    difX = 1;
                    break;
                case 'v':
                    difY = 1;
                    difX = 0;
                    break;
                case '<':
                    difY = 0;
                    difX = -1;
                    break;
                default:
                    continue;
            }
            
            if (CheckMove(map, x, y, difX, difY))
            {
                x += difX;
                y += difY;
            }
            
        }
        
        int res = 0;

        for (int i = 0; i < map.Count; i++)
        {
            Console.Write('\n');
            for (int j = 0; j < map[0].Length; j++)
            {
                if (map[i][j] == 'O')
                {
                    res += i * 100 + j;
                }
                Console.Write(map[i][j]);
            }
        }
        
        return "Answer for part 1: " + res;
    }

    private bool CheckMove(List<char[]> map, int x, int y, int difX, int difY)
    {
        if (map[y + difY][x + difX] == 'O')
        {
            bool moved = CheckMove(map, x + difX, y + difY, difX, difY);
            if (moved)
                (map[y + difY][x + difX], map[y][x]) = (map[y][x], map[y + difY][x + difX]);
            return moved;
        }
        if(map[y + difY][x + difX] == '.')
        {
            (map[y + difY][x + difX], map[y][x]) = (map[y][x], map[y + difY][x + difX]);
            return true;
        }
        return false;
    }

    private string PartTwo()
    {
        Console.WriteLine("input: ");
        List<List<char>> map = new List<List<char>>();
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            List<char> line = new List<char>();
            for (int i = 0; i < next.Length; i++)
            {
                line.Add(next[i]);
            }
            map.Add(line);
            next = Console.ReadLine();
        }

        string moves = "";
        next = Console.ReadLine();
        while (next != String.Empty)
        {
            moves += next;
            next = Console.ReadLine();
        }

        int x = 0, y = 0;
        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map[0].Count; j++)
            {
                switch (map[i][j])
                {
                    case '@':
                        x = j;
                        y = i;
                        map[i][j] = '.';
                        map[i].Insert(j, '@');
                        j++;
                        break;
                    case 'O':
                        map[i][j] = ']';
                        map[i].Insert(j, '[');
                        j++;
                        break;
                    case '#':
                        map[i].Insert(j, '#');
                        j++;
                        break;
                    case '.':
                        map[i].Insert(j, '.');
                        j++;
                        break;
                }
            }
        }
        
        for (int i = 0; i < map.Count; i++)
        {
            Console.Write('\n');
            for (int j = 0; j < map[0].Count; j++)
            {
                Console.Write(map[i][j]);
            }
        }

        int difX, difY;
        
        for (int i = 0; i < moves.Length; i++)
        {
            switch (moves[i])
            {
                case '^':
                    difY = -1;
                    difX = 0;
                    break;
                case '>':
                    difY = 0;
                    difX = 1;
                    break;
                case 'v':
                    difY = 1;
                    difX = 0;
                    break;
                case '<':
                    difY = 0;
                    difX = -1;
                    break;
                default:
                    continue;
            }
            
            if (CheckBigMove(map, x, y, difX, difY))
            {
                BigMove(map, x, y, difX, difY);
                x += difX;
                y += difY;
            }
            
        }
        
        int res = 0;

        for (int i = 0; i < map.Count; i++)
        {
            Console.Write('\n');
            for (int j = 0; j < map[0].Count; j++)
            {
                if (map[i][j] == '[')
                {
                    res += i * 100 + j;
                }
                Console.Write(map[i][j]);
            }
        }
        return "Answer for part 2: " + res;
    }
    
    private bool CheckBigMove(List<List<char>> map, int x, int y, int difX, int difY)
    {
        bool up = difX == 0;
        
        if(map[y + difY][x + difX] == '.')
        {
            return true;
        }
        if(map[y + difY][x + difX] == '#')
        {
            return false;
        }
        
        if (up)
        {
            if (map[y + difY][x + difX] == '[')
            {
                bool moved;
                bool moved2 = true;
                if (map[y][x] != '[')
                {
                    moved = CheckBigMove(map, x + difX, y + difY, difX, difY);
                    moved2 = CheckBigMove(map, x + difX + 1, y + difY, difX, difY);
                }
                else
                {
                    moved = CheckBigMove(map, x + difX, y + difY, difX, difY);
                }

                return moved && moved2;
            }
            if (map[y + difY][x + difX] == ']')
            {
                bool moved;
                bool moved2 = true;
                if (map[y][x] != ']')
                {
                    moved = CheckBigMove(map, x + difX, y + difY, difX, difY);
                    moved2 = CheckBigMove(map, x + difX - 1, y + difY, difX, difY);
                }
                else
                {
                    moved = CheckBigMove(map, x + difX, y + difY, difX, difY);
                }

                return moved && moved2;
            }

            return false;
        }
        return CheckBigMove(map, x + difX, y + difY, difX, difY);
    }

    private void BigMove(List<List<char>> map, int x, int y, int difX, int difY)
    {
        bool up = difX == 0;
        
        if(map[y + difY][x + difX] == '.')
        {
            (map[y + difY][x + difX], map[y][x]) = (map[y][x], map[y + difY][x + difX]);
            return;
        }
        
        if (up)
        {
            if (map[y + difY][x + difX] == '[')
            {
                if (map[y][x] != '[')
                {
                    BigMove(map, x + difX, y + difY, difX, difY);
                    BigMove(map, x + difX + 1, y + difY, difX, difY);
                    (map[y + difY][x + difX], map[y][x]) = (map[y][x], map[y + difY][x + difX]);
                    return;
                }
                BigMove(map, x + difX, y + difY, difX, difY);
                (map[y + difY][x + difX], map[y][x]) = (map[y][x], map[y + difY][x + difX]);
                return;
            }
            if (map[y + difY][x + difX] == ']')
            {
                if (map[y][x] != ']')
                {
                    BigMove(map, x + difX, y + difY, difX, difY);
                    BigMove(map, x + difX - 1, y + difY, difX, difY);
                    (map[y + difY][x + difX], map[y][x]) = (map[y][x], map[y + difY][x + difX]);
                    return;
                }
                BigMove(map, x + difX, y + difY, difX, difY);
                (map[y + difY][x + difX], map[y][x]) = (map[y][x], map[y + difY][x + difX]);
            }
        }
        else
        {
            BigMove(map, x + difX, y + difY, difX, difY);
            (map[y + difY][x + difX], map[y][x]) = (map[y][x], map[y + difY][x + difX]);
        }
    }
}