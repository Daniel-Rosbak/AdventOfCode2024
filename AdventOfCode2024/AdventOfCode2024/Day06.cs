
using System.Numerics;

namespace AdventOfCode2024;

public class Day06 : Day
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

        int X = 0, Y = 0, maxX = input[0].Length, maxY = input.Count;
        bool done = false;

        for (int i = 0; i < maxY; i++)
        {
            for (int j = 0; j < maxX; j++)
            {
                char tile = input[i][j];
                bool isGuard = tile == '^' || tile == '<' || tile == '>' || tile == 'v';
                if (isGuard)
                {
                    X = j;
                    Y = i;
                    done = true;
                    break;
                }
            }
            if (done)
            {
                break;
            }
        }

        int prevX = X, prevY = Y, res = 1;
        bool onBoard = true;
        
        while (onBoard)
        {
            char current = input[Y][X];
            input[Y][X] = 'X';
            switch (current)
            {
                case '^':
                    prevY = Y;
                    Y -= 1;
                    break;
                case '<':
                    prevX = X;
                    X -= 1;
                    break;
                case '>':
                    prevX = X;
                    X += 1;
                    break;
                case 'v':
                    prevY = Y;
                    Y += 1;
                    break;
            }

            if (X < 0 || Y < 0 || Y >= maxY || X >= maxX)
            {
                onBoard = false;
                break;
            }
            
            if (input[Y][X] == '#')
            {
                switch (current)
                {
                    case '^':
                        Y += 1;
                        X += 1;
                        current = '>';
                        break;
                    case '<':
                        X += 1;
                        Y -= 1;
                        current = '^';
                        break;
                    case '>':
                        X -= 1;
                        Y += 1;
                        current = 'v';
                        break;
                    case 'v':
                        Y -= 1;
                        X -= 1;
                        current = '<';
                        break;
                }
            }

            if (input[Y][X] != 'X')
            {
                res++;
            }
            input[Y][X] = current;
        }
        
        return res.ToString();
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
                List<char[]> clone = new List<char[]>();
                for (int k = 0; k < input.Count; k++)
                {
                    clone.Add((char[])input[k].Clone());
                }

                clone[i][j] = '#';
                
                if (Walk(clone))
                {
                    res++;
                    Console.WriteLine(res);
                }
            }
        }
        
        //~20 min.
        return "Answer for part 2: " + res;
    }
    
    private bool Walk(List<char[]> input)
    {
        int X = 0, Y = 0, maxX = input[0].Length, maxY = input.Count;
        bool done = false;

        for (int i = 0; i < maxY; i++)
        {
            for (int j = 0; j < maxX; j++)
            {
                char tile = input[i][j];
                bool isGuard = tile == '^' || tile == '<' || tile == '>' || tile == 'v';
                if (isGuard)
                {
                    X = j;
                    Y = i;
                    done = true;
                    break;
                }
            }
            if (done)
            {
                break;
            }
        }
        if (!done)
        {
            return false;
        }

        int prevX = X, prevY = Y;
        List<string> visited = new List<string>();
        
        while (true)
        {
            char current = input[Y][X];
            input[Y][X] = 'X';
            switch (current)
            {
                case '^':
                    prevY = Y;
                    Y -= 1;
                    break;
                case '<':
                    prevX = X;
                    X -= 1;
                    break;
                case '>':
                    prevX = X;
                    X += 1;
                    break;
                case 'v':
                    prevY = Y;
                    Y += 1;
                    break;
            }

            if (X < 0 || Y < 0 || Y >= maxY || X >= maxX)
            {
                return false;
            }
            
            if (input[Y][X] == '#')
            {
                switch (current)
                {
                    case '^':
                        Y += 1;
                        //X += 1;
                        current = '>';
                        break;
                    case '<':
                        X += 1;
                        //Y -= 1;
                        current = '^';
                        break;
                    case '>':
                        X -= 1;
                        //Y += 1;
                        current = 'v';
                        break;
                    case 'v':
                        Y -= 1;
                        //X -= 1;
                        current = '<';
                        break;
                }
            }
            string here = X.ToString("D3") + Y.ToString("D3") + current;
            if (visited.Contains(here))
            {
                return true;
            }
            visited.Add(here);
            input[Y][X] = current;
        }
    }
}