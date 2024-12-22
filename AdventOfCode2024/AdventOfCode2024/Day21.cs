namespace AdventOfCode2024;

public class Day21 : Day
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
        
        Dictionary<int, int[]> numPad = new Dictionary<int, int[]>();
        // -1 = A
        numPad[-1] = new[] { 2, 3 };
        numPad[0] = new[] { 1, 3 };
        numPad[1] = new[] { 0, 2 };
        numPad[2] = new[] { 1, 2 };
        numPad[3] = new[] { 2, 2 };
        numPad[4] = new[] { 0, 1 };
        numPad[5] = new[] { 1, 1 };
        numPad[6] = new[] { 2, 1 };
        numPad[7] = new[] { 0, 0 };
        numPad[8] = new[] { 1, 0 };
        numPad[9] = new[] { 2, 0 };
        Dictionary<int, int[]> keyPad = new Dictionary<int, int[]>();
        // -1 = A
        keyPad[-1] = new[] { 2, 0 };
        // 0 = ^
        keyPad[0] = new[] { 1, 0 };
        // 1 = >
        keyPad[1] = new[] { 2, 1 };
        // 2 = v
        keyPad[2] = new[] { 1, 1 };
        // 3 = <
        keyPad[3] = new[] { 0, 1 };
        
        int res = 0;

        for (int i = 0; i < input.Count; i++)
        {
            int[] numPadRobot = { 2, 3 }, keyPadRobotOne = { 2, 0 }, keyPadRobotTwo = { 2, 0 };
            List<int[]> moves = new List<int[]>();
            List<int[]> priorMoves = new List<int[]>();
            for (int j = 0; j < input[i].Length; j++)
            {
                char cNumber = input[i][j];
                int number;
                if (cNumber == 'A')
                    number = -1;
                else
                    number = int.Parse(cNumber.ToString());

                int[] nextKey = numPad[number];

                moves.Add(new[] { nextKey[0] - numPadRobot[0], nextKey[1] - numPadRobot[1], number});

                numPadRobot = nextKey;
            }

            //robots to control
            priorMoves = moves;
            moves = new List<int[]>();
            int movingFrom = -1, movingTo;
            for (int j = 0; j < priorMoves.Count; j++)
            {
                int[] move = priorMoves[j];
                int x = move[0], y = move[1];
                movingTo = move[2];
                if (!((movingFrom == -1 || movingFrom == 0) && (movingTo == 1 || movingTo == 4 || movingTo == 7)))
                {
                    if (x != 0)
                    {
                        int keyX = x < 0 ? 3 : 1;
                        moves.Add(new[] { keyPad[keyX][0] - keyPadRobotOne[0], keyPad[keyX][1] - keyPadRobotOne[1], keyX});
                        keyPadRobotOne = keyPad[keyX];
                        x += x < 0 ? 1 : -1;

                        for (int k = x; k != 0; k += k < 0 ? 1 : -1)
                        {
                            moves.Add(new[] { 0, 0, keyX});
                        }
                    }

                    if (y != 0)
                    {
                        int keyY = y < 0 ? 0 : 2;
                        moves.Add(new[] { keyPad[keyY][0] - keyPadRobotOne[0], keyPad[keyY][1] - keyPadRobotOne[1], keyY});
                        keyPadRobotOne = keyPad[keyY];
                        y += y < 0 ? 1 : -1;

                        for (int k = y; k != 0; k += k < 0 ? 1 : -1)
                        {
                            moves.Add(new[] { 0, 0, keyY});
                        }
                    }
                }
                else
                {
                    if (y != 0)
                    {
                        int keyY = y < 0 ? 0 : 2;
                        moves.Add(new[] { keyPad[keyY][0] - keyPadRobotOne[0], keyPad[keyY][1] - keyPadRobotOne[1], keyY});
                        keyPadRobotOne = keyPad[keyY];
                        y += y < 0 ? 1 : -1;

                        for (int k = y; k != 0; k += k < 0 ? 1 : -1)
                        {
                            moves.Add(new[] { 0, 0, keyY});
                        }
                    }

                    if (x != 0)
                    {
                        int keyX = x < 0 ? 3 : 1;
                        moves.Add(new[] { keyPad[keyX][0] - keyPadRobotOne[0], keyPad[keyX][1] - keyPadRobotOne[1], keyX});
                        keyPadRobotOne = keyPad[keyX];
                        x += x < 0 ? 1 : -1;

                        for (int k = x; k != 0; k += k < 0 ? 1 : -1)
                        {
                            moves.Add(new[] { 0, 0, keyX});
                        }
                    }
                }

                moves.Add(new[] { keyPad[-1][0] - keyPadRobotOne[0], keyPad[-1][1] - keyPadRobotOne[1], -1 });
                keyPadRobotOne = keyPad[-1];

                movingFrom = movingTo;
            }

            priorMoves = moves;
            moves = new List<int[]>();
            movingFrom = -1;
            for (int j = 0; j < priorMoves.Count; j++)
            {
                int[] move = priorMoves[j];
                int x = move[0], y = move[1];

                movingTo = move[2];
                if (!((movingFrom == -1 || movingFrom == 0) && movingTo == 3))
                {
                    if (x != 0)
                    {
                        int keyX = x < 0 ? 3 : 1;
                        moves.Add(new[] { keyPad[keyX][0] - keyPadRobotOne[0], keyPad[keyX][1] - keyPadRobotOne[1] });
                        keyPadRobotOne = keyPad[keyX];
                        x += x < 0 ? 1 : -1;

                        for (int k = x; k != 0; k += k < 0 ? 1 : -1)
                        {
                            moves.Add(new[] { 0, 0 });
                        }
                    }

                    if (y != 0)
                    {
                        int keyY = y < 0 ? 0 : 2;
                        moves.Add(new[] { keyPad[keyY][0] - keyPadRobotOne[0], keyPad[keyY][1] - keyPadRobotOne[1] });
                        keyPadRobotOne = keyPad[keyY];
                        y += y < 0 ? 1 : -1;

                        for (int k = y; k != 0; k += k < 0 ? 1 : -1)
                        {
                            moves.Add(new[] { 0, 0 });
                        }
                    }
                }
                else
                {
                    if (y != 0)
                    {
                        int keyY = y < 0 ? 0 : 2;
                        moves.Add(new[] { keyPad[keyY][0] - keyPadRobotOne[0], keyPad[keyY][1] - keyPadRobotOne[1] });
                        keyPadRobotOne = keyPad[keyY];
                        y += y < 0 ? 1 : -1;

                        for (int k = y; k != 0; k += k < 0 ? 1 : -1)
                        {
                            moves.Add(new[] { 0, 0 });
                        }
                    }

                    if (x != 0)
                    {
                        int keyX = x < 0 ? 3 : 1;
                        moves.Add(new[] { keyPad[keyX][0] - keyPadRobotOne[0], keyPad[keyX][1] - keyPadRobotOne[1] });
                        keyPadRobotOne = keyPad[keyX];
                        x += x < 0 ? 1 : -1;

                        for (int k = x; k != 0; k += k < 0 ? 1 : -1)
                        {
                            moves.Add(new[] { 0, 0 });
                        }
                    }
                }

                moves.Add(new[] { keyPad[-1][0] - keyPadRobotOne[0], keyPad[-1][1] - keyPadRobotOne[1] });
                keyPadRobotOne = keyPad[-1];

                movingFrom = movingTo;
            }

            int sequenceLength = 0;

            Console.WriteLine();
            for (int j = 0; j < moves.Count; j++)
            {
                int[] move = moves[j];
                Console.Write(move[0] + "" + move[1] + "A");
                sequenceLength++;
                sequenceLength += Math.Abs(move[0]);
                sequenceLength += Math.Abs(move[1]);
            }

            res += sequenceLength * int.Parse(input[i].Remove(3));
            Console.WriteLine(sequenceLength + " " + input[i].Remove(3));
        }
        
        //94758 too high
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