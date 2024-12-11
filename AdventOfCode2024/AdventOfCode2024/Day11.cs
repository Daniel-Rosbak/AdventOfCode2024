namespace AdventOfCode2024;

public class Day11 : Day
{
    public override string Run()
    {
        return PartTwo();
    }
    
    private string PartOne()
    {
        Console.WriteLine("input: ");
        string input = Console.ReadLine();

        string[] split = input.Split(" ");
        List<long> stones = new List<long>();
        
        for (int i = 0; i < split.Length; i++)
        {
            stones.Add(int.Parse(split[i]));
        }
        
        long res = CountStones(stones, 25);
        
        return "Answer for part 1: " + res;
    }

    private string PartTwo()
    {
        Console.WriteLine("input: ");
        string input = Console.ReadLine();

        string[] split = input.Split(" ");
        List<long> stones = new List<long>();
        
        for (int i = 0; i < split.Length; i++)
        {
            stones.Add(int.Parse(split[i]));
        }
        
        long res = CountStones(stones, 75);
        
        return "Answer for part 2: " + res;
    }

    private Dictionary<string, long> memoisedStones;
    
    private long CountStones(List<long> stones, int blinks)
    {
        long count = 0;
        memoisedStones = new Dictionary<string, long>();
        
        Console.WriteLine("Counting:");
        
        for (int i = 0; i < stones.Count; i++)
        {
            count += Stones(stones[i], blinks);
            Console.WriteLine((((float)i + 1) / stones.Count).ToString("P"));
        }
        
        return count;
    }
    
    private long Stones(long stone, int blinks)
    {
        long count;
        string key = stone + " " + blinks;
        
        if (memoisedStones.TryGetValue(key, out count))
        {
            return count;
        }

        count = 0;
        
        if (blinks > 0)
        {
            if (stone == 0)
            {
                count += Stones(1, blinks - 1);
                memoisedStones.Add(key, count);
                return count;
            }
            
            int length = (int)Math.Log10(stone) + 1;
            
            if (length % 2 == 0)
            {
                count += Stones(stone % (int)Math.Pow(10, length / 2), blinks - 1);
                count += Stones(stone / (int)Math.Pow(10, length/2), blinks - 1);
                memoisedStones.Add(key, count);
                return count;
            }

            count += Stones(stone * 2024, blinks - 1);
            memoisedStones.Add(key, count);
            return count;
        }
        memoisedStones.Add(key, 1);
        return 1;
    }
}