﻿namespace AdventOfCode2024;

public class DaySelector
{
    public static void Main()
    {
        Day day = new Day24();
        Console.WriteLine(day.Run());
    }
}