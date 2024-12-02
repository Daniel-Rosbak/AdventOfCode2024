namespace AdventOfCode2024;

public class Day02 : Day
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

        List<List<int>> reports = new List<List<int>>();

        foreach (string report in input)
        {
            string[] levels = report.Split(" ");
            List<int> reportList = new List<int>();
            reports.Add(reportList);
            foreach (string level in levels)
            {
                reportList.Add(int.Parse(level));
            }
        }
        int res = 0;

        foreach (List<int> report in reports)
        {
            bool safe = true;
            bool descending = report[0] > report[1];
            
            for (int i = 0; i < report.Count - 1; i++)
            {
                int change = report[i] - report[i + 1];
                if (change < -3 || change > 3 || change == 0)
                {
                    safe = false;
                    break;
                }
                if (descending && change < 0 || !descending && change > 0)
                {
                    safe = false;
                    break;
                }
            }

            if (safe)
            {
                res++;
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
        
        List<List<int>> reports = new List<List<int>>();

        foreach (string report in input)
        {
            string[] levels = report.Split(" ");
            List<int> reportList = new List<int>();
            reports.Add(reportList);
            foreach (string level in levels)
            {
                reportList.Add(int.Parse(level));
            }
        }

        int res = 0;

        foreach (List<int> report in reports)
        {
            bool safe = true;
            bool safetyDampened = false;
            int overallChange = 0;
            for (int i = 0; i < report.Count - 1; i++)
            {
                overallChange += report[i + 1] - report[i];
            }
            
            for (int i = 0; i < report.Count - 1; i++)
            {
                int change = report[i + 1] - report[i];
                
                if (change < -3 || change > 3 || change == 0)
                {
                    safe = false;
                }
                if (overallChange > 0 && change < 0 || overallChange < 0 && change > 0)
                {
                    safe = false;
                }

                if (!safe && !safetyDampened)
                {
                    safetyDampened = true;
                    safe = true;
                    
                    if (i == 0)
                    {
                        change = report[i + 2] - report[i + 1];
                        if (change < -3 || change > 3 || change == 0)
                        {
                            safe = false;
                        }
                        if (overallChange > 0 && change < 0 || overallChange < 0 && change > 0)
                        {
                            safe = false;
                        }

                        if (safe)
                        {
                            report.RemoveAt(i);
                        }
                        else
                        {
                            report.RemoveAt(i + 1);
                        }
                    }
                    else
                    {
                        report.RemoveAt(i + 1);
                    }
                    i--;
                    
                }
            }

            if (safe)
            {
                res++;
            }
        }
        
        return res.ToString();
    }
}