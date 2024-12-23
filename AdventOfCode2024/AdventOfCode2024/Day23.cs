namespace AdventOfCode2024;

public class Day23 : Day
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

        Dictionary<string, List<string>> connections = new Dictionary<string, List<string>>();
        
        for (int i = 0; i < input.Count; i++)
        {
            if (!connections.ContainsKey(input[i].Substring(0,2)))
            {
                connections[input[i].Substring(0, 2)] = new List<string>();
            }
            if (!connections.ContainsKey(input[i].Substring(3,2)))
            {
                connections[input[i].Substring(3,2)] = new List<string>();
            }
            connections[input[i].Substring(0,2)].Add(input[i].Substring(3,2));
            connections[input[i].Substring(3,2)].Add(input[i].Substring(0,2));
        }

        Dictionary<string, bool> seen = new Dictionary<string, bool>();
        
        foreach (KeyValuePair<string, List<string>> pair in connections)
        {
            string pcOne = pair.Key;
            List<string> cons = pair.Value;
            for (int i = 0; i < cons.Count; i++)
            {
                string pcTwo = cons[i], pcThree;

                for (int j = 0; j < cons.Count; j++)
                {
                    if (j == i)
                        continue;
                    
                    pcThree = cons[j];
                    if (connections[pcTwo].Contains(pcThree))
                    {
                        List<string> network = new List<string>();
                        network.Add(pcOne);
                        network.Add(pcTwo);
                        network.Add(pcThree);
                        network.Sort();
                        string networkKey = network[0] + network[1] + network[2];
                        if (pcOne[0] == 't' || pcTwo[0] == 't' || pcThree[0] == 't')
                        {
                            seen[networkKey] = true;
                        }
                        else
                        {
                            seen[networkKey] = false;
                        }
                    }
                }
            }
        }

        int res = 0;

        foreach (KeyValuePair<string, bool> pair in seen)
        {
            if (pair.Value)
            {
                res++;
            }
        }
        
        return "Answer for part 1: " + seen.Count + " " + res;
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

        Dictionary<string, List<string>> connections = new Dictionary<string, List<string>>();
        
        for (int i = 0; i < input.Count; i++)
        {
            if (!connections.ContainsKey(input[i].Substring(0,2)))
            {
                connections[input[i].Substring(0, 2)] = new List<string>();
            }
            if (!connections.ContainsKey(input[i].Substring(3,2)))
            {
                connections[input[i].Substring(3,2)] = new List<string>();
            }
            connections[input[i].Substring(0,2)].Add(input[i].Substring(3,2));
            connections[input[i].Substring(3,2)].Add(input[i].Substring(0,2));
        }

        Dictionary<string, bool> seen = new Dictionary<string, bool>();

        List<string> biggestNetwork = new List<string>();
        
        foreach (KeyValuePair<string, List<string>> pair in connections)
        {
            List<string> cons = pair.Value;
            List<string> network = new List<string>();
            for (int k = 0; k < cons.Count; k++)
            {
                network = new List<string>(cons);
                network.Insert(0, network[k]);
                network.RemoveAt(k + 1);
                for (int i = 0; i < network.Count; i++)
                {
                    string pcTwo = network[i];

                    for (int j = 0; j < network.Count; j++)
                    {
                        if (i == j)
                            continue;
                        if (!connections[pcTwo].Contains(network[j]))
                        {
                            network.RemoveAt(j);
                            if (i > j)
                            {
                                i--;
                            }

                            j--;
                        }
                    }
                }
                network.Add(pair.Key);
                if (biggestNetwork.Count < network.Count)
                {
                    biggestNetwork = network;
                }
            }
        }

        string res = "";
        biggestNetwork.Sort();

        for (int i = 0; i < biggestNetwork.Count; i++)
        {
            res += biggestNetwork[i] + ",";
        }

        res = res.Remove(res.Length - 1);
        
        return "Answer for part 2: " + res;
    }
}