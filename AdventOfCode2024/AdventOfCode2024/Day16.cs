namespace AdventOfCode2024;

public class Day16 : Day
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

        int x = 1, y = input.Count - 2, face = 0, res = int.MaxValue, cost = 0;
        List<int[]> Heads = new List<int[]>();
        Dictionary<string, int> flowField = new Dictionary<string, int>();
        Heads.Add(new []{x, y, face, cost});

        while (Heads.Count > 0)
        {
            for (int i = 0; i < Heads.Count; i++)
            {
                x = Heads[i][0];
                y = Heads[i][1];
                face = Heads[i][2];
                cost = Heads[i][3];
                
                if (input[y][x] == 'E')
                {
                    res = res < Heads[i][3] ? res : Heads[i][3];
                    Heads.RemoveAt(i);
                    continue;
                }

                int temp;
                if (flowField.TryGetValue(x + " " + y + " " + face, out temp))
                {
                    if (temp < cost)
                    {
                        Heads.RemoveAt(i);
                        continue;
                    }
                }

                flowField[x + " " + y + " " + face] = cost;
                
                switch (face)
                {
                    case 0:
                        if (input[y - 1][x] != '#')
                        {
                            Heads.Add(new []{x, y - 1, 1, cost + 1001});
                        }
                        if (input[y + 1][x] != '#')
                        {
                            Heads.Add(new []{x, y + 1, 3, cost + 1001});
                        }
                        if (input[y][x + 1] == '#')
                        {
                            Heads.RemoveAt(i);
                        }
                        else
                        {
                            Heads[i][0]++;
                            Heads[i][3]++;
                        }
                        break;
                    case 1:
                        if (input[y][x - 1] != '#')
                        {
                            Heads.Add(new []{x - 1, y, 2, cost + 1001});
                        }
                        if (input[y][x + 1] != '#')
                        {
                            Heads.Add(new []{x + 1, y, 0, cost + 1001});
                        }
                        if (input[y - 1][x] == '#')
                        {
                            Heads.RemoveAt(i);
                        }
                        else
                        {
                            Heads[i][1]--;
                            Heads[i][3]++;
                        }
                        break;
                    case 2:
                        if (input[y - 1][x] != '#')
                        {
                            Heads.Add(new []{x, y - 1, 1, cost + 1001});
                        }
                        if (input[y + 1][x] != '#')
                        {
                            Heads.Add(new []{x, y + 1, 3, cost + 1001});
                        }
                        if (input[y][x - 1] == '#')
                        {
                            Heads.RemoveAt(i);
                        }
                        else
                        {
                            Heads[i][0]--;
                            Heads[i][3]++;
                        }
                        break;
                    case 3:
                        if (input[y][x - 1] != '#')
                        {
                            Heads.Add(new []{x - 1, y, 2, cost + 1001});
                        }
                        if (input[y][x + 1] != '#')
                        {
                            Heads.Add(new []{x + 1, y, 0, cost + 1001});
                        }
                        if (input[y + 1][x] == '#')
                        {
                            Heads.RemoveAt(i);
                        }
                        else
                        {
                            Heads[i][1]++;
                            Heads[i][3]++;
                        }
                        break;
                }
            }
        }
        
        return "Answer for part 1: " + res;
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
        
        int x = 1, y = input.Count - 2, face = 0, cost = 0;
        List<List<List<int>>> Heads = new List<List<List<int>>>();
        Dictionary<string, int> flowField = new Dictionary<string, int>();
        List<int> head = new List<int>();
        head.Add(x);
        head.Add(y);
        head.Add(face);
        head.Add(cost);
        List<List<int>> Header = new List<List<int>>();
        Header.Add(head);
        List<int> visited = new List<int>();
        Header.Add(visited);
        Heads.Add(Header);

        List<List<List<int>>> bestPaths = new List<List<List<int>>>();
        Header = new List<List<int>>();
        head = new List<int>();
        head.Add(0);
        head.Add(0);
        head.Add(0);
        head.Add(int.MaxValue);
        Header.Add(head);
        bestPaths.Add(Header);

        while (Heads.Count > 0)
        {
            for (int i = 0; i < Heads.Count; i++)
            {
                x = Heads[i][0][0];
                y = Heads[i][0][1];
                face = Heads[i][0][2];
                cost = Heads[i][0][3];
                
                Heads[i][1].Add(x);
                Heads[i][1].Add(y);
                
                if (input[y][x] == 'E')
                {
                    if (bestPaths[0][0][3] > cost)
                    {
                        bestPaths.Clear();
                        bestPaths.Add(Heads[i]);
                    }
                    else if (bestPaths[0][0][3] == cost)
                    {
                        bestPaths.Add(Heads[i]);
                    }
                    Heads.RemoveAt(i);
                    continue;
                }

                int temp;
                if (flowField.TryGetValue(x + " " + y + " " + face, out temp))
                {
                    if (temp < cost)
                    {
                        Heads.RemoveAt(i);
                        continue;
                    }
                }

                flowField[x + " " + y + " " + face] = cost;
                
                switch (face)
                {
                    case 0:
                        if (input[y - 1][x] != '#')
                        {
                            head = new List<int>();
                            head.Add(x);
                            head.Add(y - 1);
                            head.Add(1);
                            head.Add(cost + 1001);
                            Header = new List<List<int>>();
                            Header.Add(head);
                            Header.Add(new List<int>(Heads[i][1]));
                            Heads.Add(Header);
                        }
                        if (input[y + 1][x] != '#')
                        {
                            head = new List<int>();
                            head.Add(x);
                            head.Add(y + 1);
                            head.Add(3);
                            head.Add(cost + 1001);
                            Header = new List<List<int>>();
                            Header.Add(head);
                            Header.Add(new List<int>(Heads[i][1]));
                            Heads.Add(Header);
                        }
                        if (input[y][x + 1] == '#')
                        {
                            Heads.RemoveAt(i);
                        }
                        else
                        {
                            Heads[i][0][0]++;
                            Heads[i][0][3]++;
                        }
                        break;
                    case 1:
                        if (input[y][x - 1] != '#')
                        {
                            head = new List<int>();
                            head.Add(x - 1);
                            head.Add(y);
                            head.Add(2);
                            head.Add(cost + 1001);
                            Header = new List<List<int>>();
                            Header.Add(head);
                            Header.Add(new List<int>(Heads[i][1]));
                            Heads.Add(Header);
                        }
                        if (input[y][x + 1] != '#')
                        {
                            head = new List<int>();
                            head.Add(x + 1);
                            head.Add(y);
                            head.Add(0);
                            head.Add(cost + 1001);
                            Header = new List<List<int>>();
                            Header.Add(head);
                            Header.Add(new List<int>(Heads[i][1]));
                            Heads.Add(Header);
                        }
                        if (input[y - 1][x] == '#')
                        {
                            Heads.RemoveAt(i);
                        }
                        else
                        {
                            Heads[i][0][1]--;
                            Heads[i][0][3]++;
                        }
                        break;
                    case 2:
                        if (input[y - 1][x] != '#')
                        {
                            head = new List<int>();
                            head.Add(x);
                            head.Add(y - 1);
                            head.Add(1);
                            head.Add(cost + 1001);
                            Header = new List<List<int>>();
                            Header.Add(head);
                            Header.Add(new List<int>(Heads[i][1]));
                            Heads.Add(Header);
                        }
                        if (input[y + 1][x] != '#')
                        {
                            head = new List<int>();
                            head.Add(x);
                            head.Add(y + 1);
                            head.Add(3);
                            head.Add(cost + 1001);
                            Header = new List<List<int>>();
                            Header.Add(head);
                            Header.Add(new List<int>(Heads[i][1]));
                            Heads.Add(Header);
                        }
                        if (input[y][x - 1] == '#')
                        {
                            Heads.RemoveAt(i);
                        }
                        else
                        {
                            Heads[i][0][0]--;
                            Heads[i][0][3]++;
                        }
                        break;
                    case 3:
                        if (input[y][x - 1] != '#')
                        {
                            head = new List<int>();
                            head.Add(x - 1);
                            head.Add(y);
                            head.Add(2);
                            head.Add(cost + 1001);
                            Header = new List<List<int>>();
                            Header.Add(head);
                            Header.Add(new List<int>(Heads[i][1]));
                            Heads.Add(Header);
                        }
                        if (input[y][x + 1] != '#')
                        {
                            head = new List<int>();
                            head.Add(x + 1);
                            head.Add(y);
                            head.Add(0);
                            head.Add(cost + 1001);
                            Header = new List<List<int>>();
                            Header.Add(head);
                            Header.Add(new List<int>(Heads[i][1]));
                            Heads.Add(Header);
                        }
                        if (input[y + 1][x] == '#')
                        {
                            Heads.RemoveAt(i);
                        }
                        else
                        {
                            Heads[i][0][1]++;
                            Heads[i][0][3]++;
                        }
                        break;
                }
            }
        }

        List<string> bestTiles = new List<string>();
        
        for (int i = 0; i < bestPaths.Count; i++)
        {
            for (int j = 0; j < bestPaths[i][1].Count; j += 2)
            {
                string here = bestPaths[i][1][j] + " " + bestPaths[i][1][j + 1];
                if (!bestTiles.Contains(here))
                {
                    bestTiles.Add(here);
                }
            }
        }

        for (int i = 0; i < input.Count; i++)
        {
            Console.Write("\n");
            for (int j = 0; j < input[0].Length; j++)
            {
                if (bestTiles.Contains(j + " " + i))
                {
                    Console.Write("O");
                }
                else
                {
                    Console.Write(input[i][j]);
                }
            }
        }
        
        return "Answer for part 2: " + bestTiles.Count;
    }
}