using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;
using Hub.Helpers;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

namespace Hub.Days
{
    internal class Day5
    {
        public static async Task Run(int day)
        {
            Console.WriteLine($"\n--- Day {day} --- \n");

            var sampleData = await InputDataHelper.GetTestData(FileNameHelper.GetSampleDataFileName(day));
            var realData = await InputDataHelper.GetRealData(FileNameHelper.GetRealFileName(day));

            PuzzleOne(sampleData);
            PuzzleTwo(sampleData);

            PuzzleOne(realData);
            PuzzleTwo(realData);
        }

        private static void PuzzleOneDummy(string[] inputData)
        {
            var columnsList = new List<List<string>>();
            var columns = new List<int>() { 1, 2, 3 };
            for (int i = 0; i < columns.Count; i++)
            {
                columnsList.Add(new List<string>());
            }

            var actionList = new List<string>();
            var test1 = "move 1 from 2 to 1";
            var test2 = "move 3 from 1 to 3";
            var test3 = "move 2 from 2 to 1";
            var test4 = "move 1 from 1 to 2";
            actionList.Add(test1);
            actionList.Add(test2);
            actionList.Add(test3);
            actionList.Add(test4);

            var actions = new List<Action>();


            foreach (var row in actionList)
            {
                var actionNumber = row.Where(char.IsDigit).Select(x => int.Parse(x.ToString())).ToList();

                if (actionNumber.Count == 3)
                {
                    actions.Add(new Action()
                    { Amount = actionNumber[0], From = actionNumber[1] - 1, To = actionNumber[2] - 1 });
                }
            }

            columnsList[0].Add("N");
            columnsList[0].Add("Z");

            columnsList[1].Add("D");
            columnsList[1].Add("C");
            columnsList[1].Add("M");

            columnsList[2].Add("P");


            foreach (var action in actions)
            {
                var itemToMoves = columnsList[action.From].Take(action.Amount).ToList();
                itemToMoves.Reverse();
                columnsList[action.From].RemoveRange(0, action.Amount);
                columnsList[action.To].InsertRange(0, itemToMoves);
            }

            var result = columnsList.Select(sublist => sublist.First()).ToList();
            foreach (var res in result)
            {
                Console.Write(res);
            }
        }

        private static void PuzzleOne(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 1 ---");

            var firstEmptyLineIndex = Array.FindIndex(inputData, string.IsNullOrWhiteSpace);
            var cargoRowsIndex = firstEmptyLineIndex - 1;


            var columnsList = new List<List<string>>();
            var numberOfColumns = inputData[cargoRowsIndex].Replace(" ", string.Empty).Select(x => int.Parse(x.ToString())).ToList();

            // Create x amount of lists to hold cargo 
            for (int i = 0; i < numberOfColumns.Count; i++)
            {
                columnsList.Add(new List<string>());
            }

            // Add cargo to correct list
            for (int i = 0; i < cargoRowsIndex; i++)
            {
                var cargoIndex = 1;
                var line = inputData[i];
                for (int j = 0; j < numberOfColumns.Count; j++)
                {
                    if (char.IsLetter(line[cargoIndex]))
                    {
                        columnsList[j].Add(line[cargoIndex].ToString());
                    }

                    cargoIndex += 4;
                }
            }

            // Add all actions to list
            var actions = new List<Action>();
            int id = 1;
            foreach (var row in inputData.Skip(firstEmptyLineIndex + 1))
            {
                //var actionNumber = row.Where(char.IsDigit).Select(x => int.Parse(x.ToString())).ToList();

                var actionNumbers = row.Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();

                actions.Add(new Action()
                { Amount = actionNumbers[0], From = actionNumbers[1] - 1, To = actionNumbers[2] - 1 });
            }


            foreach (var action in actions)
            {
                var itemToMoves = columnsList[action.From].Take(action.Amount).ToList();
                itemToMoves.Reverse();
                columnsList[action.From].RemoveRange(0, action.Amount);
                columnsList[action.To].InsertRange(0, itemToMoves);
            }

            var result = columnsList.Select(sublist => sublist.First()).ToList();
            foreach (var res in result)
            {
                Console.Write(res);
            }
        }

        private static void PuzzleTwo(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");

            var firstEmptyLineIndex = Array.FindIndex(inputData, string.IsNullOrWhiteSpace);
            var cargoRowsIndex = firstEmptyLineIndex - 1;


            var columnsList = new List<List<string>>();
            var numberOfColumns = inputData[cargoRowsIndex].Replace(" ", string.Empty).Select(x => int.Parse(x.ToString())).ToList();

            // Create x amount of lists to hold cargo 
            for (int i = 0; i < numberOfColumns.Count; i++)
            {
                columnsList.Add(new List<string>());
            }

            // Add cargo to correct list
            for (int i = 0; i < cargoRowsIndex; i++)
            {
                var cargoIndex = 1;
                var line = inputData[i];
                for (int j = 0; j < numberOfColumns.Count; j++)
                {
                    if (char.IsLetter(line[cargoIndex]))
                    {
                        columnsList[j].Add(line[cargoIndex].ToString());
                    }

                    cargoIndex += 4;
                }
            }

            // Add all actions to list
            var actions = new List<Action>();
            int id = 1;
            foreach (var row in inputData.Skip(firstEmptyLineIndex + 1))
            {
                //var actionNumber = row.Where(char.IsDigit).Select(x => int.Parse(x.ToString())).ToList();

                var actionNumbers = row.Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();

                actions.Add(new Action()
                { Amount = actionNumbers[0], From = actionNumbers[1] - 1, To = actionNumbers[2] - 1 });
            }


            foreach (var action in actions)
            {
                var itemToMoves = columnsList[action.From].Take(action.Amount).ToList();
                //itemToMoves.Reverse();
                columnsList[action.From].RemoveRange(0, action.Amount);
                columnsList[action.To].InsertRange(0, itemToMoves);
            }

            var result = columnsList.Select(sublist => sublist.First()).ToList();
            foreach (var res in result)
            {
                Console.Write(res);
            }

        }
    }

    class Action
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
}
