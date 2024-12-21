namespace AdventOfCode2024;

public class Day20 : Day
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

        char[,] map = new char[input.Count,input[0].Length];
        int x = 0, y = 0, max = input.Count;
        
        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < max; j++)
            {
                if (input[i][j] == 'S')
                {
                    x = j;
                    y = i;
                }
                map[i,j] = input[i][j];
            }
        }

        int standardCost = shortestPath(map, max, x, y), res = 0;

        for (int i = 1; i < max - 1; i++)
        {
            for (int j = 1; j < max - 1; j++)
            {
                if (map[i,j] == '#')
                {
                    map[i,j] = '.';
                    if (standardCost - shortestPath(map, max, x, y) > 99)
                    {
                        res++;
                    }
                    map[i, j] = '#';
                }
            }
            Console.WriteLine(((float)(i + 1)/max).ToString("P") + " " + res);
        }
        
        return "Answer for part 1: " + res;
    }

    private int shortestPath(char[,] map, int max , int X, int Y)
    {
        //modified day 18 algorithm
        Dictionary<string, int> costMap = new Dictionary<string, int>();
        List<List<int>> heads = new List<List<int>>();
        List<int> head = new List<int>();
        head.Add(X);
        head.Add(Y);
        head.Add(0);
        heads.Add(head);

        int[,] dirs = new int[4,2];
        dirs[0, 0] = -1;
        dirs[0, 1] = 0;
        dirs[1, 0] = 0;
        dirs[1, 1] = -1;
        dirs[2, 0] = 1;
        dirs[2, 1] = 0;
        dirs[3, 0] = 0;
        dirs[3, 1] = 1;
        
        int res = int.MaxValue;

        while (heads.Count > 0)
        {
            int count = heads.Count;
            for (int i = 0; i < count; i++)
            {
                int x = heads[i][0];
                int y = heads[i][1];
                int cost = heads[i][2] + 1;

                if (map[y,x] == 'E')
                {
                    return cost - 1;
                }

                for (int j = 0; j < 4; j++)
                {
                    if (x + dirs[j, 0] > max - 1 || x + dirs[j, 0] < 0 || y + dirs[j, 1] > max - 1 || y + dirs[j, 1] < 0)
                    {
                        continue;
                    }
                    if (map[y + dirs[j,1],x + dirs[j,0]] != '#')
                    {
                        int curCost;
                        if (costMap.TryGetValue((x + dirs[j,0]) + " " + (y + dirs[j,1]), out curCost))
                        {
                            if (curCost > cost)
                            {
                                costMap[(x + dirs[j,0]) + " " + (y + dirs[j,1])] = cost;
                                head = new List<int>(heads[i]);
                                head[0] += dirs[j,0];
                                head[1] += dirs[j,1];
                                head[2]++;
                                heads.Add(head);
                            }
                        }
                        else
                        {
                            costMap[(x + dirs[j,0]) + " " + (y + dirs[j,1])] = cost;
                            head = new List<int>(heads[i]);
                            head[0] += dirs[j,0];
                            head[1] += dirs[j,1];
                            head[2]++;
                            heads.Add(head);
                        }
                    }
                }

                heads.RemoveAt(i);
                i--;
                count--;
            }
        }
        
        return res;
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

        char[,] map = new char[input.Count,input[0].Length];
        int x = 0, y = 0, max = input.Count, endX = 0, endY = 0;
        
        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < max; j++)
            {
                if (input[i][j] == 'S')
                {
                    x = j;
                    y = i;
                }
                if (input[i][j] == 'E')
                {
                    endX = j;
                    endY = i;
                }
                map[i,j] = input[i][j];
            }
        }

        Dictionary<string, int[]> path = mapper(map, max, endX, endY);
        Dictionary<int, int> waysToCheat = new Dictionary<int, int>();
        for (int i = 0; i < path[x + " " + y][2] + 1; i++)
        {
            waysToCheat[i] = 0;
        }
        int res = 0;

        while (true)
        {
            int cost = path[x + " " + y][2];
            int[] spot;
            for (int k = 1; k < 21; k++)
            {
                for (int l = 0; l < k; l++)
                {
                    //top left
                    if (path.TryGetValue((x - l) + " " + (y - k + l), out spot))
                    {
                        if (cost - 99 > spot[2] + k - 1)
                        {
                            res++;
                        }
                    }
                    //top right
                    if (path.TryGetValue((x + k - l) + " " + (y - l), out spot))
                    {
                        if (cost - 99 > spot[2] + k - 1)
                        {
                            res++;
                        }
                    }
                    //bot right
                    if (path.TryGetValue((x + l) + " " + (y + k - l), out spot))
                    {
                        if (cost - 99 > spot[2] + k - 1)
                        {
                            res++;
                        }
                    }
                    //bot left
                    if (path.TryGetValue((x - k + l) + " " + (y + l), out spot))
                    {
                        if (cost - 99 > spot[2] + k - 1)
                        {
                            res++;
                        }
                    }
                }
            }

            spot = path[x + " " + y];

            x = spot[0];
            y = spot[1];
            if (map[y,x] == 'E')
                break;
        }
        
        return "Answer for part 2: " + res;
    }
    
    private Dictionary<string, int[]> mapper(char[,] map, int max , int x, int y)
    {
        //modified day 18 algorithm
        Dictionary<string, int[]> path = new Dictionary<string, int[]>();
        path[x + " " + y] = new[] { -1, -1, 0 };
        int cost = 1;
        int priorX = -1;
        int priorY = -1;

        int[,] dirs = new int[4,2];
        dirs[0, 0] = -1;
        dirs[0, 1] = 0;
        dirs[1, 0] = 0;
        dirs[1, 1] = -1;
        dirs[2, 0] = 1;
        dirs[2, 1] = 0;
        dirs[3, 0] = 0;
        dirs[3, 1] = 1;
        
        int res = int.MaxValue;

        while (true)
        {
            if (map[y,x] == 'S')
            {
                return path;
            }

            for (int j = 0; j < 4; j++)
            {
                int newX = x + dirs[j, 0], newY = y + dirs[j,1];
                if (newX > max - 1 || newX < 0 || newY > max - 1 || newY < 0)
                {
                    continue;
                }
                if (map[newY,newX] != '#')
                {
                    if (!(priorX ==  newX && priorY == newY))
                    {
                        path[newX + " " + newY] = new[] { x, y , cost};
                        priorX = x;
                        priorY = y;
                        x = newX;
                        y = newY;
                        cost++;
                    }
                }
            }
        }
    }
}