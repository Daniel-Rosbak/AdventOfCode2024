namespace AdventOfCode2024;

public class Day08 : Day
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
        
        int height = input.Count, width = input[0].Length;
        bool[,] antiNodes = new bool[height,width];
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                char here = input[i][j];
                if (here != '.')
                {
                    for (int k = 0; k < height; k++)
                    {
                        for (int l = 0; l < width; l++)
                        {
                            if (input[k][l] == here && !(k == i && l == j))
                            {
                                int difX = l - j, difY = k - i, dX, dY;
                                
                                dY = i - difY;
                                dX = j - difX;
                                if (dY >= 0 && dY < height && dX >= 0 && dX < width)
                                {
                                    antiNodes[dY, dX] = true;
                                }

                                dY = k + difY;
                                dX = l + difX;
                                if (dY >= 0 && dY < height && dX >= 0 && dX < width)
                                {
                                    antiNodes[dY, dX] = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        int res = 0;
        Console.Write('\n');
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (antiNodes[i,j])
                {
                    Console.Write('O');
                    res++;
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.Write('\n');
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

        int height = input.Count, width = input[0].Length;
        bool[,] antiNodes = new bool[height,width];
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                char here = input[i][j];
                if (here != '.')
                {
                    for (int k = 0; k < height; k++)
                    {
                        for (int l = 0; l < width; l++)
                        {
                            if (input[k][l] == here && !(k == i && l == j))
                            {
                                int difX = l - j, difY = k - i, dX, dY;
                                bool inside = true;
                                
                                dY = i;
                                dX = j;
                                while (inside)
                                {
                                    if (dY >= 0 && dY < height && dX >= 0 && dX < width)
                                    {
                                        antiNodes[dY, dX] = true;
                                    }
                                    else
                                    {
                                        inside = false;
                                    }
                                    dY -= difY;
                                    dX -= difX;
                                }

                                inside = true;
                                dY = k;
                                dX = l;
                                while (inside)
                                {
                                    if (dY >= 0 && dY < height && dX >= 0 && dX < width)
                                    {
                                        antiNodes[dY, dX] = true;
                                    }
                                    else
                                    {
                                        inside = false;
                                    }
                                    dY += difY;
                                    dX += difX;
                                }
                            }
                        }
                    }
                }
            }
        }

        int res = 0;
        Console.Write('\n');
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (antiNodes[i,j])
                {
                    Console.Write('O');
                    res++;
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.Write('\n');
        }
        
        return "Answer for part 2: " + res;
    }
}