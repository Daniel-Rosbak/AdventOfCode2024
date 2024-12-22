namespace AdventOfCode2024;

public class Day22 : Day
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

        long res = 0;
        
        for (int i = 0; i < input.Count; i++)
        {
            res += Find2000ThNumber(long.Parse(input[i]));
        }
        
        
        return "Answer for part 1: " + res;
    }

    private long Find2000ThNumber(long startingNumber)
    {
        for (int i = 0; i < 2000; i++)
        {
            startingNumber ^= startingNumber * 64;
            startingNumber %= 16777216;
            startingNumber ^= startingNumber / 32;
            startingNumber %= 16777216;
            startingNumber ^= startingNumber * 2048;
            startingNumber %= 16777216;
        }
        
        return startingNumber;
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

        List<Dictionary<string, int>> changesPerSecret = new List<Dictionary<string, int>>();
        for (int i = 0; i < input.Count; i++)
        {
            changesPerSecret.Add(GetChanges(long.Parse(input[i])));
        }

        int res = 0;
        for (int i = 0; i < changesPerSecret.Count; i++)
        {
            foreach (KeyValuePair<string, int> pair in changesPerSecret[i])
            {
                int potentialProfit = 0;
                string pattern = pair.Key;
                for (int j = 0; j < changesPerSecret.Count; j++)
                {
                    if (changesPerSecret[j].TryGetValue(pattern, out int price))
                    {
                        potentialProfit += price;
                    }
                }

                if (pattern == "-2 1 -1 3")
                {
                    if (changesPerSecret[i].TryGetValue(pattern, out int p))
                    {
                        Console.WriteLine(i + "" + p);
                    }
                }

                if (potentialProfit >= res)
                {
                    res = potentialProfit;
                }
            }
        }
        
        return "Answer for part 2: " + res;
    }
    
    private Dictionary<string, int> GetChanges(long startingNumber)
    {
        Dictionary<string, int> marks = new Dictionary<string, int>();
        int[] changes = new int [2001];
        int prior = (int)(startingNumber%10);
        changes[0] = prior;
        
        for (int i = 0; i < 2000; i++)
        {
            startingNumber ^= startingNumber * 64;
            startingNumber %= 16777216;
            startingNumber ^= startingNumber / 32;
            startingNumber %= 16777216;
            startingNumber ^= startingNumber * 2048;
            startingNumber %= 16777216;
            changes[i + 1] = (int)(startingNumber % 10) - prior;
            prior = (int)(startingNumber % 10);
        }

        int price = changes[0] + changes[1] + changes[2] + changes[3];

        for (int i = 4; i < changes.Length; i++)
        {
            price += changes[i];
            string here = changes[i - 3] + " " + changes[i - 2] + " " + changes[i - 1] + " " + changes[i];
            if (marks.ContainsKey(here))
            {
                break;
            }
            marks[here] = price;
        }
        
        return marks;
    }
}