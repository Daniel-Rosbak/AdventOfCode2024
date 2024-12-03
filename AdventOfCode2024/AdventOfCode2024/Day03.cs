using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class Day03 : Day
{
    public override string Run()
    {
        return PartTwo();
    }
    
    private string PartOne()
    {
        Console.WriteLine("input: ");
        string input = "";
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            input += next;
            next = Console.ReadLine();
        }

        MatchCollection instructions = Regex.Matches(input, @"mul\(\d\d?\d?\,\d\d?\d?\)");

        int res = 0;

        foreach (Match match in instructions)
        {
            MatchCollection nums = Regex.Matches(match.Value, @"\d\d?\d?");
            res += int.Parse(nums[0].Value) * int.Parse(nums[1].Value);
        }
        
        return res.ToString();
    }

    private string PartTwo()
    {
        Console.WriteLine("input: ");
        string input = "";
        string next = Console.ReadLine();
        while (next != String.Empty)
        {
            input += next;
            next = Console.ReadLine();
        }

        MatchCollection instructions = Regex.Matches(input, @"don?'?t?\(\)|mul\(\d\d?\d?\,\d\d?\d?\)");

        int res = 0;
        bool doMul = true;
        
        foreach (Match match in instructions)
        {
            switch (match.Value)
            {
                case "do()":
                    doMul = true;
                    break;
                case "don't()":
                    doMul = false;
                    break;
                default:
                    if (doMul)
                    {
                        MatchCollection nums = Regex.Matches(match.Value, @"\d\d?\d?");
                        res += int.Parse(nums[0].Value) * int.Parse(nums[1].Value);
                    }
                    break;
            }
        }
        
        return res.ToString();
    }
}