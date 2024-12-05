namespace AdventOfCode2024;

public class Day05 : Day
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
        bool almostDone = false;
        while (next != String.Empty || almostDone != true)
        {
            if (next == string.Empty)
            {
                almostDone = true;
            }
            input.Add(next);
            next = Console.ReadLine();
        }

        Dictionary<int, List<int>> rules = new Dictionary<int, List<int>>();
        bool go = true;
        while (go)
        {
            if (input[0] == string.Empty)
            {
                input.RemoveAt(0);
                break;
            }

            int key = int.Parse(input[0].Substring(0, 2));
            try
            {
                rules[key].Add(int.Parse(input[0].Substring(3, 2)));
            }
            catch (Exception e)
            {
                List<int> rule = new List<int>();
                rule.Add(int.Parse(input[0].Substring(3, 2)));
                rules.Add(key,rule);
            }
            input.RemoveAt(0);
        }
        
        int res = 0;

        foreach (string update in input)
        {
            string[] stringPages = update.Split(",");
            List<int> pages = new List<int>();
            for (int i = 0; i < stringPages.Length; i++)
            {
                pages.Add(int.Parse(stringPages[i]));
            }

            bool rightOrder = true;
            for (int i = 0; i < pages.Count; i++)
            {
                int currentPage = pages[i];
                for (int j = 0; j < pages.Count; j++)
                {
                    try
                    {
                        if (rules[currentPage].Contains(pages[j]) && i > j)
                        {
                            rightOrder = false;
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }

                if (!rightOrder)
                {
                    break;
                }
            }

            if (rightOrder)
            {
                res += pages[pages.Count / 2];
            }
        }
        
        return res.ToString();
    }

    private string PartTwo()
    {
        Console.WriteLine("input: ");
        List<string> input = new List<string>();
        string next = Console.ReadLine();
        bool almostDone = false;
        while (next != String.Empty || almostDone != true)
        {
            if (next == string.Empty)
            {
                almostDone = true;
            }
            input.Add(next);
            next = Console.ReadLine();
        }

        Dictionary<int, List<int>> rules = new Dictionary<int, List<int>>();
        bool go = true;
        while (go)
        {
            if (input[0] == string.Empty)
            {
                input.RemoveAt(0);
                break;
            }

            int key = int.Parse(input[0].Substring(0, 2));
            try
            {
                rules[key].Add(int.Parse(input[0].Substring(3, 2)));
            }
            catch (Exception e)
            {
                List<int> rule = new List<int>();
                rule.Add(int.Parse(input[0].Substring(3, 2)));
                rules.Add(key,rule);
            }
            input.RemoveAt(0);
        }
        
        int res = 0;

        foreach (string update in input)
        {
            string[] stringPages = update.Split(",");
            List<int> pages = new List<int>();
            for (int i = 0; i < stringPages.Length; i++)
            {
                pages.Add(int.Parse(stringPages[i]));
            }

            bool correctedOrder = false;
            for (int i = 0; i < pages.Count; i++)
            {
                int currentPage = pages[i];
                List<int> rule;
                bool exists = rules.TryGetValue(currentPage, out rule);
                if (exists)
                {
                    for (int j = 0; j < pages.Count; j++)
                    {
                        if (rule.Contains(pages[j]) && i > j)
                        {
                            pages.Insert(i + 1, pages[j]);
                            pages.RemoveAt(j);
                            
                            correctedOrder = true;
                            i -= 1;
                        }
                    }
                }
            }

            if (correctedOrder)
            {
                res += pages[pages.Count / 2];
            }
        }
        
        return res.ToString();
    }
}