namespace AdventOfCode2024;

public class Day19 : Day
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

        List<string> towels = new List<string>();
        int longestTowel = 0;
        
        for (int i = 0; i < input.Count; i++)
        {
            string[] strings = input[i].Split(", ");
            for (int j = 0; j < strings.Length; j++)
            {
                if (!towels.Contains(strings[j]))
                {
                    longestTowel = longestTowel > strings[j].Length ? longestTowel : strings[j].Length;
                    towels.Add(strings[j]);
                }
            }
        }

        List<string> designs = new List<string>();
        
        next = Console.ReadLine();
        while (next != String.Empty)
        {
            designs.Add(next);
            next = Console.ReadLine();
        }

        int res = 0;
        bool done;
        
        for (int i = 0; i < designs.Count; i++)
        {
            done = false;
            List<string> combinations = new List<string>();
            combinations.Add(designs[i]);
            while (combinations.Count != 0)
            {
                int count = combinations.Count;
                for (int k = 0; k < count; k++)
                {
                    for (int j = 0; j < towels.Count; j++)
                    {
                        if (combinations[k].StartsWith(towels[j]))
                        {
                            string newCombination = combinations[k].Substring(towels[j].Length);
                            if (newCombination.Length == 0)
                            {
                                done = true;
                                res++;
                                break;
                            }

                            if (!combinations.Contains(newCombination))
                                combinations.Add(newCombination);
                        }
                    }

                    if (done)
                        break;
                    combinations.RemoveAt(k);
                    k--;
                    count--;
                }

                if (done)
                    break;
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

        List<string> towels = new List<string>();
        int longestTowel = 0;
        
        for (int i = 0; i < input.Count; i++)
        {
            string[] strings = input[i].Split(", ");
            for (int j = 0; j < strings.Length; j++)
            {
                if (!towels.Contains(strings[j]))
                {
                    longestTowel = longestTowel > strings[j].Length ? longestTowel : strings[j].Length;
                    towels.Add(strings[j]);
                }
            }
        }

        List<string> designs = new List<string>();
        
        next = Console.ReadLine();
        while (next != String.Empty)
        {
            designs.Add(next);
            next = Console.ReadLine();
        }

        long res = 0;
        
        for (int i = 0; i < designs.Count; i++)
        {
            List<string> combinations = new List<string>();
            combinations.Add(designs[i]);
            Dictionary<string, long> paths = new Dictionary<string, long>();
            paths[designs[i]] = 1;
            while (combinations.Count != 0)
            {
                int count = combinations.Count;
                for (int k = 0; k < count; k++)
                {
                    for (int j = 0; j < towels.Count; j++)
                    {
                        if (combinations[k].StartsWith(towels[j]))
                        {
                            string newCombination = combinations[k].Substring(towels[j].Length);
                            if (newCombination.Length == 0)
                            {
                                res += paths[combinations[k]];
                            }
                            else
                            {
                                if (!combinations.Contains(newCombination))
                                {
                                    combinations.Add(newCombination);
                                    paths[newCombination] = paths[combinations[k]];
                                }
                                else
                                {
                                    paths[newCombination] += paths[combinations[k]];
                                }
                            }
                        }
                    }
                    combinations.RemoveAt(k);
                    k--;
                    count--;
                }
            }
        }
        
        return "Answer for part 2: " + res;
    }
}