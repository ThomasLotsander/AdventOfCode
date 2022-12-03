using Hub.Helpers;

namespace Hub.Days
{
    public static class Day3
    {
        private static Dictionary<char, int> _alphabetPriority;

        public static async Task Run()
        {
            Console.WriteLine("\n--- Day 3 --- \n");

            var sampleData = await InputDataHelper.GetTestData(FileNameHelper.GetSampleDataFileName(3));
            var realData = await InputDataHelper.GetRealData(FileNameHelper.GetRealFileName(3));

            _alphabetPriority = new Dictionary<char, int>();
            _alphabetPriority.AddAlphabet();

            PuzzleOne(sampleData);
            PuzzleOne(realData);

            PuzzleTwo(sampleData);
            PuzzleTwo(realData);
        }

        private static void PuzzleOne(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 1 ---");

            var totalScore = 0;
            foreach (var input in inputData)
            {
                var half = input.Length / 2;
                var first = input.Substring(0, (half));
                var last = input.Substring((half), (half));

                var equipment = first.Intersect(last).FirstOrDefault();
                totalScore += _alphabetPriority[equipment];
            }

            Console.WriteLine(totalScore);
        }

        private static void PuzzleTwo(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");
            var totalScore = 0;
            var inputList = inputData.ToList();
            do
            {
                var group = inputList.Take(3).ToList();
                var equipment = group[0].Intersect(group[1].Intersect(group[2])).FirstOrDefault();
                inputList.RemoveRange(0, 3);

                totalScore += _alphabetPriority[equipment];
            } while (inputList.Any());

            Console.WriteLine(totalScore);
        }

        private static void AddAlphabet(this Dictionary<char, int> alphabet)
        {
            var index = 1;
            for (var c = 'a'; c <= 'z'; c++, index++)
            {
                alphabet.Add(c, index);
            }

            for (var c = 'A'; c <= 'Z'; c++, index++)
            {
                alphabet.Add(c, index);
            }
        }
    }
}