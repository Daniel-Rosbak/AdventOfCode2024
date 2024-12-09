namespace AdventOfCode2024;

public class Day09 : Day
{
    public override string Run()
    {
        return PartTwo();
    }
    
    private string PartOne()
    {
        string input = File.ReadAllText(@"..\..\..\Input.txt");

        List<int> disk = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            disk.Add(int.Parse(input[i].ToString()));
        }
        
        List<int> compactDisk = new List<int>();
        if (disk.Count % 2 == 0)
        {
            disk.RemoveAt(disk.Count - 1);
        }

        for (int i = 0; i < disk.Count; i++)
        {
            if (i % 2 != 0)
            {
                for (int j = 0; j < disk[i]; j++)
                {
                    compactDisk.Add((disk.Count - 1) / 2);
                    disk[^1] -= 1;
                    
                    if (disk[^1] == 0)
                    {
                        disk.RemoveAt(disk.Count - 1);
                        disk.RemoveAt(disk.Count - 1);
                    }
                }
            }
            else
            {
                for (int j = 0; j < disk[i]; j++)
                {
                    compactDisk.Add(i/2);
                }
            }
        }

        long res = 0;
        for (int i = 0; i < compactDisk.Count; i++)
        {
            res += compactDisk[i] * i;
        }
        
        return "Answer for part 1: " + res;
    }

    private string PartTwo()
    {
        string input = File.ReadAllText(@"..\..\..\Input.txt");

        List<int> disk = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            disk.Add(int.Parse(input[i].ToString()));
        }
        if (disk.Count % 2 == 0)
        {
            disk.RemoveAt(disk.Count - 1);
        }
        
        List<List<int>> intermediateDisk = new List<List<int>>();

        for (int i = 0; i < disk.Count; i++)
        {
            if (i % 2 == 0)
            {
                List<int> block = new List<int>();

                block.Add(0);
                block.Add(disk[i]);
                block.Add(i/2);
                block.Add(0);
                
                intermediateDisk.Add(block);
            }
            else
            {
                List<int> block = new List<int>();
                
                block.Add(1);
                block.Add(disk[i]);
                
                intermediateDisk.Add(block);
            }
        }

        for (int i = intermediateDisk.Count - 1; i > 0; i--)
        {
            if (intermediateDisk[i][0] == 0 && intermediateDisk[i][3] == 0)
            {
                for (int j = 0; j < i; j++)
                {
                    if (intermediateDisk[j][0] == 1)
                    {
                        int space = intermediateDisk[j][1];
                        int block = intermediateDisk[i][1];
                        if (block <= space)
                        {
                            intermediateDisk[i][3] = 1;
                            List<int> num = new List<int>();
                            num.Add(intermediateDisk[i][0]);
                            num.Add(intermediateDisk[i][1]);
                            num.Add(intermediateDisk[i][2]);
                            num.Add(intermediateDisk[i][3]);
                            intermediateDisk.Insert(j, num);
                            intermediateDisk[i + 1][0] = 1;
                            intermediateDisk[i + 1].RemoveAt(2);
                            intermediateDisk[i + 1].RemoveAt(2);
                            intermediateDisk[j + 1][1] -= block;
                            break;
                        }
                    }
                }
            }
        }

        List<int> compactDisk = new List<int>();
        
        for (int i = 0; i < intermediateDisk.Count; i++)
        {
            if (intermediateDisk[i][0] == 0)
            {
                for (int j = 0; j < intermediateDisk[i][1]; j++)
                {
                    compactDisk.Add(intermediateDisk[i][2]);
                }
            }
            else
            {
                for (int j = 0; j < intermediateDisk[i][1]; j++)
                {
                    compactDisk.Add(0);
                }
            }
        }
        
        long res = 0;

        for (int i = 0; i < compactDisk.Count; i++)
        {
            res += compactDisk[i] * i;
        }
        
        return "Answer for part 2: " + res;
    }
}