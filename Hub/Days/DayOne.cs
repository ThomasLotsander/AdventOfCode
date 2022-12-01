using Hub.Helpers;

namespace Hub.Days
{
    public static class DayOne
    {
        public static void Run(string inputData)
        {
            var sampleData = SampleDataHelper.Day1SampleData;
            PuzzleOne(inputData);
            PuzzleTwo(inputData);
        }

        private static void PuzzleOne(string inputData)
        {
            var highestCount = 0;
            var currentCount = 0;
            foreach (var input in inputData.Split('\n'))
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

        private static void PuzzleTwo(string inputData)
        {
            var list = new List<int>();
            var currentCount = 0;

            foreach (var input in inputData.Split('\n'))
            {
                if (string.IsNullOrEmpty(input))
                {
                    if (list.Count < 3)
                        list.Add(currentCount);
                    else
                    {
                        if (currentCount > list.Min())
                        {
                            list.RemoveAt(0);
                            list.Add(currentCount);
                        }
                    }

                    currentCount = 0;

                    list.Sort();
                    continue;
                }

                currentCount += int.Parse(input);
            }

            var total = list.Sum();
            Console.WriteLine(total);
        }
    }
}