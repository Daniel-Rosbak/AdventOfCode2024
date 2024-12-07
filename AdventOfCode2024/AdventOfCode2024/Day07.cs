namespace AdventOfCode2024;

public class Day07 : Day
{
    public override string Run()
    {
        return PartTwo();
    }
    
    private string PartOne()
    {
        Console.WriteLine("input: ");
        List<string[]> input = new List<string[]>();
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            input.Add(next.Split(" "));
            next = Console.ReadLine();
        }
        
        List<long> testResults = new List<long>();
        List<List<long>> combos = new List<List<long>>();
        for (int i = 0; i < input.Count; i++)
        {
            testResults.Add(long.Parse(input[i][0].Substring(0, input[i][0].Length - 1)));
            List<long> combo = new List<long>();
            for (int j = 1; j < input[i].Length; j++)
            {
                combo.Add(long.Parse(input[i][j]));
            }
            combos.Add(combo);
        }

        long res = 0;
        
        for (int i = 0; i < testResults.Count; i++)
        {
            long wanted = testResults[i];

            List<long> possibilities = new List<long>();
            possibilities.Add(combos[i][0]);
            
            for (int j = 1; j < combos[i].Count; j++)
            {
                long posNum = possibilities.Count;
                for (int k = 0; k < posNum; k++)
                {
                    possibilities.Add(possibilities[0] + combos[i][j]);
                    possibilities.Add(possibilities[0] * combos[i][j]);
                    possibilities.RemoveAt(0);
                }
            }

            if (possibilities.Contains(wanted))
            {
                res += wanted;
            }
        }
        
        return "Answer for part 1: " + res;
    }

    private string PartTwo()
    {
        Console.WriteLine("input: ");
        List<string[]> input = new List<string[]>();
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            input.Add(next.Split(" "));
            next = Console.ReadLine();
        }

        List<long> testResults = new List<long>();
        List<List<long>> combos = new List<List<long>>();
        for (int i = 0; i < input.Count; i++)
        {
            testResults.Add(long.Parse(input[i][0].Substring(0, input[i][0].Length - 1)));
            List<long> combo = new List<long>();
            for (int j = 1; j < input[i].Length; j++)
            {
                combo.Add(long.Parse(input[i][j]));
            }
            combos.Add(combo);
        }

        long res = 0;
        
        for (int i = 0; i < testResults.Count; i++)
        {
            long wanted = testResults[i];

            List<long> possibilities = new List<long>();
            possibilities.Add(combos[i][0]);
            
            for (int j = 1; j < combos[i].Count; j++)
            {
                long posNum = possibilities.Count;
                for (int k = 0; k < posNum; k++)
                {
                    possibilities.Add(possibilities[0] + combos[i][j]);
                    possibilities.Add(possibilities[0] * combos[i][j]);
                    possibilities.Add(long.Parse(possibilities[0].ToString() + combos[i][j]));
                    possibilities.RemoveAt(0);
                }
            }

            if (possibilities.Contains(wanted))
            {
                res += wanted;
            }
            
            Console.WriteLine(((float)i/testResults.Count).ToString("P"));
        }
        
        return "Answer for part 2: " + res;
    }
}