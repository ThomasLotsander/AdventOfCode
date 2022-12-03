using Hub.Helpers;

namespace Hub.Days
{
    public static class Day1
    {
        public static async Task Run()
        {
            Console.WriteLine("\n--- Day 1 --- \n");

            var sampleData = await InputDataHelper.GetTestData(FileNameHelper.GetSampleDataFileName(1));
            var realData = await InputDataHelper.GetRealData(FileNameHelper.GetRealFileName(1));
            PuzzleOne(sampleData);
            PuzzleOne(realData);

            PuzzleTwo(sampleData);
            PuzzleTwo(realData);
        }

        private static void PuzzleOne(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 1 ---");

            var highestCount = 0;
            var currentCount = 0;
            foreach (var input in inputData)
            {
                if (string.IsNullOrEmpty(input))
                {
                    if (currentCount > highestCount)
                    {
                        highestCount = currentCount;
                    }

                    currentCount = 0;
                    continue;
                }

                currentCount += int.Parse(input);
            }

            Console.WriteLine(highestCount);
        }

        private static void PuzzleTwo(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");

            var list = new List<int>();
            var currentCount = 0;
            foreach (var input in inputData)
            {
                if (string.IsNullOrEmpty(input))
                {
                    if (list.Count < 3)
                        list.Add(currentCount);
                    else
                    {
                        if (currentCount > list.Min())
                        {
                            list.RemoveAt(list.IndexOf(list.Min()));
                            list.Add(currentCount);
                        }
                    }

                    currentCount = 0;
                    continue;
                }

                currentCount += int.Parse(input);
            }

            Console.WriteLine(list.Sum());
        }
    }
}