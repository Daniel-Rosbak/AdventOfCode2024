
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

        int[,] Directions = {{-1,0}, {0,1}, {1,0}, {0,-1}};
        List<string> visited = new List<string>();
        int current = 0, res = 0;
        int nextX = X, nextY = Y;
        
        while (true)
        {
            nextX += Directions[current, 1];
            nextY += Directions[current, 0];
                
            if (nextX < 0 || nextY < 0 || nextX >= maxX || nextY >= maxY)
            {
                break;
            }
            
            Console.WriteLine(nextX + " , " + nextY);
            if (input[nextY][nextX] == '#')
            {
                nextX -= Directions[current, 1];
                nextY -= Directions[current, 0];
                current = (current + 1) % 4;
                continue;
            }

            int hypX = nextX, hypY = nextY, hypCurrent = current;
            input[nextY][nextX] = '#';
            
            List<char[]> clone = new List<char[]>();

            for (int i = 0; i < input.Count(); i++)
            {
                clone.Add((char[])input[i].Clone());
            }
            
            while (true)
            {
                if (input[hypY][hypX] == '#')
                {
                    hypX -= Directions[hypCurrent, 1];
                    hypY -= Directions[hypCurrent, 0];
                    hypCurrent = (hypCurrent + 1) % 4;
                }

                string here = "|" + hypX.ToString("D3") + hypY.ToString("D3") + hypCurrent + "|";
                
                if (visited.Contains(here))
                {
                    res++;
                    Console.WriteLine(res);
                    break;
                }
                
                visited.Add(here);

                clone[hypY][hypX] = 'X';
                
                hypX += Directions[hypCurrent, 1];
                hypY += Directions[hypCurrent, 0];
                
                if (hypX < 0 || hypY < 0 || hypX >= maxX || hypY >= maxY)
                {
                    break;
                }
            }
            input[nextY][nextX] = 'X';
        }

        for (int i = 0; i < input.Count; i++)
        {
            Console.WriteLine(input[i]);
        }

        return res.ToString();
    }
}