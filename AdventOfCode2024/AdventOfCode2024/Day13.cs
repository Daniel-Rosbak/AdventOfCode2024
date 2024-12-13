namespace AdventOfCode2024;

public class Day13 : Day
{
    public override string Run()
    {
        return PartTwo();
    }
    
    private string PartOne()
    {
        Console.WriteLine("input: ");
        List<string> input = new List<string>();
        string nextnext = Console.ReadLine();
        string next = " ";
        while (nextnext != string.Empty || next != string.Empty)
        {
            input.Add(nextnext);
            next = nextnext;
            nextnext = Console.ReadLine();
        }
        
        int res = 0;

        for (int i = 0; i < input.Count; i += 4)
        {
            float aX, aY, a, bX, bY, b, cX, cY;
            string[] nums = input[i].Split(" ");
            aX = int.Parse(nums[2].Substring(2,2));
            aY = int.Parse(nums[3].Substring(2));
            nums = input[i + 1].Split(" ");
            bX = int.Parse(nums[2].Substring(2,2));
            bY =int.Parse(nums[3].Substring(2));
            nums = input[i + 2].Split(" ");
            cX = int.Parse(nums[1].Replace(',',' ').Substring(2));
            cY = int.Parse(nums[2].Substring(2));

            float divisor = aY * bX - bY * aX;
            a = Math.Abs((cY * bX - bY * cX) / divisor);
            b = Math.Abs((cY * aX - aY * cX) / divisor);

            bool wholeNumberA = Math.Floor(a) == a;
            bool wholeNumberB = Math.Floor(b) == b;
            if (wholeNumberA && wholeNumberB)
            {
                if (a <= 100 && b <= 100)
                {
                    res += (int)a * 3;
                    res += (int)b * 1;
                }
            }
        }
        
        return "Answer for part 1: " + res;
    }
    
    private string PartTwo()
    {
        Console.WriteLine("input: ");
        List<string> input = new List<string>();
        string nextnext = Console.ReadLine();
        string next = " ";
        while (nextnext != string.Empty || next != string.Empty)
        {
            input.Add(nextnext);
            next = nextnext;
            nextnext = Console.ReadLine();
        }

        double res = 0;

        for (int i = 0; i < input.Count; i += 4)
        {
            double aX, aY, a, bX, bY, b, cX, cY;
            string[] nums = input[i].Split(" ");
            aX = int.Parse(nums[2].Substring(2,2));
            aY = int.Parse(nums[3].Substring(2));
            nums = input[i + 1].Split(" ");
            bX = int.Parse(nums[2].Substring(2,2));
            bY =int.Parse(nums[3].Substring(2));
            nums = input[i + 2].Split(" ");
            cX = double.Parse(nums[1].Replace(',',' ').Substring(2));
            cY = double.Parse(nums[2].Substring(2));

            cX += 10000000000000;
            cY += 10000000000000;
            
            double divisor = aY * bX - bY * aX;
            a = Math.Abs((cY * bX - bY * cX) / divisor);
            b = Math.Abs((cY * aX - aY * cX) / divisor);

            bool wholeNumberA = Math.Floor(a) == a;
            bool wholeNumberB = Math.Floor(b) == b;
            if (wholeNumberA && wholeNumberB)
            {
                res += a * 3;
                res += b * 1;
            }
        }
        
        return "Answer for part 2: " + res;
    }
}