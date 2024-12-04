namespace AdventOfCode2024;

public class Day04 : Day
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

        int res = 0;

        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[i].Length - 3; j++)
            {
                if (input[i][j] == 'X')
                {
                    if (input[i][j + 1] == 'M')
                    {
                        if (input[i][j + 2] == 'A')
                        {
                            if (input[i][j + 3] == 'S')
                            {
                                res++;
                            }
                        }
                    }
                }

                if (input[i][j] == 'S')
                {
                    if (input[i][j + 1] == 'A')
                    {
                        if (input[i][j + 2] == 'M')
                        {
                            if (input[i][j + 3] == 'X')
                            {
                                res++;
                            }
                        }
                    }
                }
            }
        }
        for (int i = 0; i < input.Count - 3; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                if (input[i][j] == 'X')
                {
                    if (input[i + 1][j] == 'M')
                    {
                        if (input[i + 2][j] == 'A')
                        {
                            if (input[i + 3][j] == 'S')
                            {
                                res++;
                            }
                        }
                    }
                }

                if (input[i][j] == 'S')
                {
                    if (input[i + 1][j] == 'A')
                    {
                        if (input[i + 2][j] == 'M')
                        {
                            if (input[i + 3][j] == 'X')
                            {
                                res++;
                            }
                        }
                    }
                }
            }
        }
        for (int i = 0; i < input.Count - 3; i++)
        {
            for (int j = 0; j < input[i].Length - 3; j++)
            {
                if (input[i][j] == 'X')
                {
                    if (input[i + 1][j + 1] == 'M')
                    {
                        if (input[i + 2][j + 2] == 'A')
                        {
                            if (input[i + 3][j + 3] == 'S')
                            {
                                res++;
                            }
                        }
                    }
                }

                if (input[i][j] == 'S')
                {
                    if (input[i + 1][j + 1] == 'A')
                    {
                        if (input[i + 2][j + 2] == 'M')
                        {
                            if (input[i + 3][j + 3] == 'X')
                            {
                                res++;
                            }
                        }
                    }
                }
            }
        }
        for (int i = 0; i < input.Count - 3; i++)
        {
            for (int j = 3; j < input[i].Length; j++)
            {
                if (input[i][j] == 'X')
                {
                    if (input[i + 1][j - 1] == 'M')
                    {
                        if (input[i + 2][j - 2] == 'A')
                        {
                            if (input[i + 3][j - 3] == 'S')
                            {
                                res++;
                            }
                        }
                    }
                }

                if (input[i][j] == 'S')
                {
                    if (input[i + 1][j - 1] == 'A')
                    {
                        if (input[i + 2][j - 2] == 'M')
                        {
                            if (input[i + 3][j - 3] == 'X')
                            {
                                res++;
                            }
                        }
                    }
                }
            }
        }
        
        return res.ToString();
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

        int res = 0;
        
        for (int i = 1; i < input.Count - 1; i++)
        {
            for (int j = 1; j < input[i].Length - 1; j++)
            {
                if (input[i][j] == 'A')
                {
                    char topleft, topright, botleft, botright;
                    topleft = input[i - 1][j - 1];
                    topright = input[i - 1][j + 1];
                    botleft = input[i + 1][j - 1];
                    botright = input[i + 1][j + 1];
                    
                    if (topleft == 'M' || topleft == 'S')
                    {
                        if (topright == 'M' || topright == 'S')
                        {
                            if ((botright == 'M' || botright == 'S') && botright != topleft)
                            {
                                if ((botleft == 'M' || botleft == 'S') && botleft != topright)
                                {
                                    res++;
                                }
                            }
                        }
                    }
                }
            }
        }
        
        return res.ToString();
    }
}