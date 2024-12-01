namespace AdventOfCode2024;

public class Day01 : Day
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

        List<int> first = new List<int>();
        List<int> second = new List<int>();

        foreach (string line in input)
        {
            first.Add(int.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]));
            second.Add(int.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]));
        }


        int res = 0;
        first.Sort();
        second.Sort();

        for (int i = 0; i < first.Count; i++)
        {
            res += Math.Abs(first[i] - second[i]);
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

        List<int> first = new List<int>();
        List<int> second = new List<int>();

        foreach (string line in input)
        {
            first.Add(int.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]));
            second.Add(int.Parse(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]));
        }


        int res = 0;
        first.Sort();
        second.Sort();

        for (int i = 0; i < first.Count; i++)
        {
            int num = first[i];
            int mul = 0;
            for (int j = 0; j < second.Count; j++)
            {
                if (second[j] == num)
                {
                    mul++;
                }
            }
            Console.WriteLine("#" + first[i]);
            Console.WriteLine("*" + mul);
            res += first[i] * mul;
        }
        
        return res.ToString();
    }
}