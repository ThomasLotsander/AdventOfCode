using Hub.Helpers;

namespace Hub.Days
{
    public static class Day1
    {
        public static async Task Run()
        {
            var sampleData = await InputDataHelper.GetTestData(InputDataHelper.Day1File);
            var realData = await InputDataHelper.GetRealData();
            PuzzleOne(sampleData);
            //PuzzleOne(realData);
            
            PuzzleTwo(sampleData);
            //PuzzleTwo(realData);
        }

        private static void PuzzleOne(string[] inputData)
        {
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

            if (currentCount > highestCount)
            {
                highestCount = currentCount;
            }

            Console.WriteLine(highestCount);
        }

        private static void PuzzleTwo(string[] inputData)
        {
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