using Hub.Helpers;

namespace Hub.Days
{
    public static class Day2
    {
        // Points
        private const int Rock = 1;

        private const int Paper = 2;
        private const int Scissors = 3;
        private const int Loss = 0;
        private const int Draw = 3;
        private const int Win = 6;

        public static async Task Run(int day)
        {
            Console.WriteLine($"\n--- Day {day} --- \n");

            var sampleData = await InputDataHelper.GetTestData(FileNameHelper.GetSampleDataFileName(day));
            var realData = await InputDataHelper.GetRealData(FileNameHelper.GetRealFileName(day));

            Puzzle1(sampleData);
            Puzzle1(realData);
            Puzzle2(sampleData);
            Puzzle2(realData);
        }

        private static void Puzzle1(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 1 ---");
            var outcomeTable = new int[3, 3];
            outcomeTable[0, 0] = Draw + Rock;
            outcomeTable[0, 1] = Win + Paper;
            outcomeTable[0, 2] = Loss + Scissors;

            outcomeTable[1, 0] = Loss + Rock;
            outcomeTable[1, 1] = Draw + Paper;
            outcomeTable[1, 2] = Win + Scissors;

            outcomeTable[2, 0] = Win + Rock;
            outcomeTable[2, 1] = Loss + Paper;
            outcomeTable[2, 2] = Draw + Scissors;

            var totalScore = 0;
            foreach (var s in inputData)
            {
                var match = s.Split(' ');
                totalScore += outcomeTable[GetMovePosition(match[0]), GetMovePosition(match[1])];
            }

            Console.WriteLine(totalScore);
        }

        private static void Puzzle2(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");

            var totalScore = 0;
            var outcomeTable = new int[3, 3];
            outcomeTable[0, 0] = Scissors + Loss;
            outcomeTable[0, 1] = Rock + Draw;
            outcomeTable[0, 2] = Paper + Win;

            outcomeTable[1, 0] = Rock + Loss;
            outcomeTable[1, 1] = Paper + Draw;
            outcomeTable[1, 2] = Scissors + Win;

            outcomeTable[2, 0] = Paper + Loss;
            outcomeTable[2, 1] = Scissors + Draw;
            outcomeTable[2, 2] = Rock + Win;

            foreach (var s in inputData)
            {
                var match = s.Split(' ');
                var opponent = GetMovePosition(match[0]);
                var desiredOutCome = GetDesiredOutcome(match[1]);
                totalScore += outcomeTable[opponent, desiredOutCome];
            }

            Console.WriteLine(totalScore);
        }

        private static int GetDesiredOutcome(string move)
        {
            switch (move)
            {
                case "X": // Loss
                    return 0;

                case "Y": // Draw
                    return 1;

                case "Z": // Win
                    return 2;

                default:
                    return 99;
            }
        }

        private static int GetMovePosition(string move)
        {
            // Rock
            if (move is "A" or "X")
                return 0;

            // Paper
            if (move is "B" or "Y")
                return 1;

            // Scissors
            return 2;
        }
    }
}