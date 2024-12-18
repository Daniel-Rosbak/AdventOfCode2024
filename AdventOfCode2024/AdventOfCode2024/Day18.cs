namespace AdventOfCode2024;

public class Day18 : Day
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

        int max = 71;
        
        char[,] map = new char[max,max];

        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < max; j++)
            {
                map[i, j] = '.';
            }
        }
        
        for (int i = 0; i < 1024; i++)
        {
            string[] nums = input[i].Split(",");
            map[int.Parse(nums[1]), int.Parse(nums[0])] = '#';
        }

        Dictionary<string, int> costMap = new Dictionary<string, int>();
        List<List<int>> heads = new List<List<int>>();
        List<int> head = new List<int>();
        head.Add(0);
        head.Add(0);
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

                if (x == max - 1 && y == max - 1)
                {
                    res = res > cost - 1 ? cost - 1 : res;
                    heads.RemoveAt(i);
                    continue;
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

        int max = 71;
        
        char[,] map = new char[max,max];

        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < max; j++)
            {
                map[i, j] = '.';
            }
        }
        
        for (int i = 0; i < 1024; i++)
        {
            string[] nums = input[i].Split(",");
            map[int.Parse(nums[1]), int.Parse(nums[0])] = '#';
        }
        
        int[,] dirs = new int[4,2];
        dirs[0, 0] = -1;
        dirs[0, 1] = 0;
        dirs[1, 0] = 0;
        dirs[1, 1] = -1;
        dirs[2, 0] = 1;
        dirs[2, 1] = 0;
        dirs[3, 0] = 0;
        dirs[3, 1] = 1;
        
        string res = "ERROR";

        for (int k = 1024; k < input.Count; k++)
        {
            string[] nums = input[k].Split(",");
            map[int.Parse(nums[1]), int.Parse(nums[0])] = '#';
            
            int output = int.MaxValue;
            Dictionary<string, int> costMap = new Dictionary<string, int>();
            List<List<int>> heads = new List<List<int>>();
            List<int> head = new List<int>();
            head.Add(0);
            head.Add(0);
            head.Add(0);
            heads.Add(head);
            
            while (heads.Count > 0)
            {
                int count = heads.Count;
                for (int i = 0; i < count; i++)
                {
                    int x = heads[i][0];
                    int y = heads[i][1];
                    int cost = heads[i][2] + 1;

                    if (x == max - 1 && y == max - 1)
                    {
                        output = output > cost - 1 ? cost - 1 : output;
                        heads.RemoveAt(i);
                        continue;
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
            
            
            if (output == int.MaxValue)
            {
                res = int.Parse(nums[0]) + "," + int.Parse(nums[1]);
                break;
            }
        }
        
        return "Answer for part 2: " + res;
    }
}