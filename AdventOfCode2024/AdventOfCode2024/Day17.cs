namespace AdventOfCode2024;

public class Day17 : Day
{
    public override string Run()
    {
        return PartTwo();
    }
    
    private string PartOne()
    {
        Console.WriteLine("input: ");
        List<long> registers = new List<long>();
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            registers.Add(long.Parse(next.Substring(12)));
            next = Console.ReadLine();
        }

        List<int> instructions = new List<int>();
        string[] inst = Console.ReadLine().Substring(9).Split(",");

        for (int i = 0; i < inst.Length; i++)
        {
            instructions.Add(int.Parse(inst[i]));
        }

        string res = "";

        for (int i = 0; i < instructions.Count; i += 2)
        {
            long literal = instructions[i + 1], combo = literal;
            switch (literal)
            {
                case 4:
                    combo = registers[0];
                    break;
                case 5:
                    combo = registers[1];
                    break;
                case 6:
                    combo = registers[2];
                    break;
            }
            
            
            switch (instructions[i])
            {
                case 0:
                    registers[0] /= (long)Math.Pow(2, combo);
                    break;
                case 1:
                    registers[1] ^= literal;
                    break;
                case 2:
                    registers[1] = combo % 8;
                    break;
                case 3:
                    if (registers[0] == 0)
                        continue;
                    i = (int)literal - 2;
                    break;
                case 4:
                    registers[1] ^= registers[2];
                    break;
                case 5:
                    res += combo % 8 + ",";
                    break;
                case 6:
                    registers[1] = registers[0] / (long)Math.Pow(2, combo);
                    break;
                case 7:
                    registers[2] = registers[0] / (long)Math.Pow(2, combo);
                    break;
            }
        }
        
        return "Answer for part 1: " + res;
    }

    private string PartTwo()
    {
        Console.WriteLine("input: ");
        List<long> registers = new List<long>();
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            registers.Add(int.Parse(next.Substring(12)));
            next = Console.ReadLine();
        }

        List<int> instructions = new List<int>();
        string program = Console.ReadLine().Substring(9);
        string[] inst = program.Split(",");

        for (int i = 0; i < inst.Length; i++)
        {
            instructions.Add(int.Parse(inst[i]));
        }

        long output = 0;
        List<long> priorres = new List<long>();
        long res = 0;
        
        bool success = true;

        for (int j = instructions.Count - 1; j >= 0; j--)
        {
            if (success)
                res = (res * 8) - 1;

            success = true;
            
            int current = instructions[j];
            
            do
            {
                res++;
                registers[0] = res;
                registers[1] = 0;
                registers[2] = 0;
            
                for (int i = 0; i < instructions.Count - 2; i += 2)
                {
                    long literal = instructions[i + 1], combo = literal;
                    switch (literal)
                    {
                        case 4:
                            combo = registers[0];
                            break;
                        case 5:
                            combo = registers[1];
                            break;
                        case 6:
                            combo = registers[2];
                            break;
                    }
            
            
                    switch (instructions[i])
                    {
                        case 0:
                            registers[0] /= (long)Math.Pow(2, combo);
                            break;
                        case 1:
                            registers[1] ^= literal;
                            break;
                        case 2:
                            registers[1] = combo % 8;
                            break;
                        case 3:
                            if (registers[0] == 0)
                                continue;
                            i = (int)literal - 2;
                            break;
                        case 4:
                            registers[1] ^= registers[2];
                            break;
                        case 5:
                            output = combo % 8;
                            break;
                        case 6:
                            registers[1] = registers[0] / (long)Math.Pow(2, combo);
                            break;
                        case 7:
                            registers[2] = registers[0] / (long)Math.Pow(2, combo);
                            break;
                    }
                }

                if (priorres.Count > 0 && res / 8 != priorres[^1])
                {
                    success = false;
                    res = priorres[^1];
                    j += 2;
                    break;
                }
                
            } while (output != current);

            if (success)
            {
                priorres.Add(res);
            }
            else
            {
                priorres.RemoveAt(priorres.Count - 1);
            }
        }
        
        return "Answer for part 2: " + res;
    }
}