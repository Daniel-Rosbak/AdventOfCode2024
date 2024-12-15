namespace AdventOfCode2024;

public class Day19 : Day
{
    public override string Run()
    {
        return PartOne();
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

        int res = 0;
        
        
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

        int res = 0;
        
        
        return "Answer for part 2: " + res;
    }
}