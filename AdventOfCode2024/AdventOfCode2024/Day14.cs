namespace AdventOfCode2024;

public class Day14 : Day
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

        int topLeft = 0, topRight = 0, botLeft = 0, botRight = 0;
        
        for (int i = 0; i < input.Count; i++)
        {
            int[] robot = new int[4];
            string[] vals = input[i].Split(" ");
            robot[0] = int.Parse(vals[0].Split(",")[0].Substring(2));
            robot[1] = int.Parse(vals[0].Split(",")[1]);
            robot[2] = int.Parse(vals[1].Split(",")[0].Substring(2));
            robot[3] = int.Parse(vals[1].Split(",")[1]);
            
            for (int j = 0; j < 100; j++)
            {
                robot[0] += robot[2];
                robot[0] = (robot[0] < 101)? robot[0] : robot[0] - 101;
                robot[0] = (robot[0] >= 0)? robot[0] : 101 + robot[0];
                
                robot[1] += robot[3];
                robot[1] = (robot[1] < 103)? robot[1] : robot[1] - 103;
                robot[1] = (robot[1] >= 0)? robot[1] : 103 + robot[1];
            }
            
            if (robot[0] < 50 && robot[1] < 51)
            {
                topLeft++;
                continue;
            }
            if (robot[0] > 50 && robot[1] < 51)
            {
                topRight++;
                continue;
            }
            if (robot[0] > 50 && robot[1] > 51)
            {
                botRight++;
                continue;
            }
            if (robot[0] < 50 && robot[1] > 51)
            {
                botLeft++;
            }
        }
        
        return "Answer for part 1: " + (topLeft * topRight * botLeft * botRight);
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

        List<int[]> robots = new List<int[]>();

        for (int i = 0; i < input.Count(); i++)
        {
            int[] robot = new int[4];
            string[] vals = input[i].Split(" ");
            robot[0] = int.Parse(vals[0].Split(",")[0].Substring(2));
            robot[1] = int.Parse(vals[0].Split(",")[1]);
            robot[2] = int.Parse(vals[1].Split(",")[0].Substring(2));
            robot[3] = int.Parse(vals[1].Split(",")[1]);
            robots.Add(robot);
        }
        
        int[,] map;
        int count = 0;
        
        while (true)
        {
            count++;
            map = new int[103,101];
            for (int i = 0; i < robots.Count; i++)
            {
                int[] robot = robots[i];
                robot[0] += robot[2];
                robot[0] = (robot[0] < 101)? robot[0] : robot[0] - 101;
                robot[0] = (robot[0] >= 0)? robot[0] : 101 + robot[0];
                
                robot[1] += robot[3];
                robot[1] = (robot[1] < 103)? robot[1] : robot[1] - 103;
                robot[1] = (robot[1] >= 0)? robot[1] : 103 + robot[1];

                map[robot[1], robot[0]]++;
            }

            int near = 0;
            
            for (int i = 0; i < robots.Count; i++)
            {
                if (robots[i][1] > 0 && robots[i][0] > 0)
                {
                    near += map[robots[i][1] - 1, robots[i][0] - 1];
                }
                if (robots[i][1] < 102 && robots[i][0] > 0)
                {
                    near += map[robots[i][1] + 1, robots[i][0] - 1];
                }
                if (robots[i][1] < 102 && robots[i][0] < 100)
                {
                    near += map[robots[i][1] + 1, robots[i][0] + 1];
                }
                if (robots[i][1] > 0 && robots[i][0] < 100)
                {
                    near += map[robots[i][1] - 1, robots[i][0] + 1];
                }
            }
            
            if (near > 500)
            {
                Console.Write("\n");
                for (int i = 0; i < 103; i++)
                {
                    Console.Write("\n");
                    for (int j = 0; j < 101; j++)
                    {
                        if (map[i,j] == 0)
                        {
                            Console.Write(".");
                        }
                        else
                        {
                            Console.Write("X");
                        }
                    }
                }
                return "Answer for part 2: " + count;
            }
        }
    }
}