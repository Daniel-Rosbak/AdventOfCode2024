namespace AdventOfCode2024;

public class Day24 : Day
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

        Dictionary<string, bool> values = new Dictionary<string, bool>();

        for (int i = 0; i < input.Count; i++)
        {
            values[input[i].Substring(0, 3)] = input[i].Substring(5) == "1";
        }

        input = new List<string>();
        next = Console.ReadLine();
        while (next != String.Empty)
        {
            input.Add(next);
            next = Console.ReadLine();
        }
        
        List<List<string>> instructions = new List<List<string>>();

        for (int i = 0; i < input.Count; i++)
        {
            List<string> instruction = new List<string>();
            string[] split = input[i].Split(" ");
            instruction.Add(split[0]);
            instruction.Add(split[1]);
            instruction.Add(split[2]);
            instruction.Add(split[4]);
            instructions.Add(instruction);
        }

        long res = RunInstructions(values, instructions);
        
        return "Answer for part 1: " + res;
    }

    private long RunInstructions(Dictionary<string, bool> values, List<List<string>> inst)
    {
        List<List<string>> instructions = new List<List<string>>(inst);
        while (instructions.Count > 0)
        {
            for (int i = 0; i < instructions.Count; i++)
            {
                List<string> instruction = instructions[i];
                if (values.ContainsKey(instruction[0]) && values.ContainsKey(instruction[2]))
                {
                    switch (instruction[1])
                    {
                        case "AND":
                            values[instruction[3]] = values[instruction[0]] & values[instruction[2]];
                            break;
                        case "XOR":
                            values[instruction[3]] = values[instruction[0]] ^ values[instruction[2]];
                            break;
                        case "OR":
                            values[instruction[3]] = values[instruction[0]] | values[instruction[2]];
                            break;
                    }
                    instructions.RemoveAt(i);
                    i--;
                }
            }
        }

        long res = 0;

        for (int i = 63; i >= 0; i--)
        {
            string key = "z" + i.ToString("D2");

            if (values.ContainsKey(key))
            {
                res <<= 1 ;
                if (values[key])
                {
                    res++;
                }
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

        Dictionary<string, bool> values = new Dictionary<string, bool>();

        for (int i = 0; i < input.Count; i++)
        {
            values[input[i].Substring(0, 3)] = input[i].Substring(5) == "1";
        }

        long x = 0, y = 0, expectedResult;
        for (int i = input.Count - 1; i >= input.Count/2; i--)
        {
            x <<= 1;
            y <<= 1;
            if (input[i].Substring(5) == "1")
            {
                y++;
            }
            if (input[i - input.Count/2].Substring(5) == "1")
            {
                x++;
            }
        }

        expectedResult = x + y;
        
        input = new List<string>();
        next = Console.ReadLine();
        while (next != String.Empty)
        {
            input.Add(next);
            next = Console.ReadLine();
        }
        
        List<List<string>> instructions = new List<List<string>>();
        Dictionary<string, string> affect = new Dictionary<string, string>();
        
        for (int i = 0; i < input.Count; i++)
        {
            List<string> instruction = new List<string>();
            string[] split = input[i].Split(" ");
            instruction.Add(split[0]);
            instruction.Add(split[1]);
            instruction.Add(split[2]);
            instruction.Add(split[4]);
            affect[split[4]] = split[0] + " " + split[1] + " " + split[2];
            instructions.Add(instruction);
        }
        
        long currentResult = RunInstructions(values, instructions);
        long flaws = currentResult ^ expectedResult;
        List<int> flawed = new List<int>();

        for (int i = 0; i < 64; i++)
        {
            if ((flaws>>i & 1) == 1)
            {
                flawed.Add(i);
            }
        }

        List<string> moved = new List<string>();
        
        while (flawed.Count > 0)
        {
            
        }

        moved.Sort();
        string res = "";
        for (int i = 0; i < moved.Count; i++)
        {
            res += moved[i] + ",";
        }

        res = res.Remove(res.Length - 1);
        
        return "Answer for part 2: " + res;
    }
}