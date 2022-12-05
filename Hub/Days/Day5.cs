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

        private static List<List<string>> CreateCargoContainers(int numberOfColumns)
        {
            var columnsList = new List<List<string>>();
            for (int i = 0; i < numberOfColumns; i++)
            {
                columnsList.Add(new List<string>());
            }

            return columnsList;
        }

        private static void AddCargoToContainers(List<List<string>> cargoContainers, string[] cargoData)
        {
            foreach (var row in cargoData)
            {
                var cargoIndex = 1;
                foreach (var container in cargoContainers)
                {
                    if (char.IsLetter(row[cargoIndex]))
                    {
                        container.Add(row[cargoIndex].ToString());
                    }

                    cargoIndex += 4;
                }
            }
        }

        private static void RearrangeCargo(List<List<string>> cargoContainers, string[] rearrangeActions, bool reverse = true)
        {
            foreach (var action in rearrangeActions)
            {
                var actions = action.Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();
                var amount = actions[0];
                var from = actions[1] - 1;
                var to = actions[2] - 1;

                var itemToMoves = cargoContainers[from].Take(amount).ToList();
                if (reverse)
                    itemToMoves.Reverse();

                cargoContainers[from].RemoveRange(0, amount);
                cargoContainers[to].InsertRange(0, itemToMoves);
            }
        }

        private static void PuzzleOne(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 1 ---");

            var firstEmptyLineIndex = Array.FindIndex(inputData, string.IsNullOrWhiteSpace);
            var cargoRowsIndex = firstEmptyLineIndex - 1;
            var numberOfColumns = inputData[cargoRowsIndex].Replace(" ", string.Empty).Select(x => int.Parse(x.ToString())).Count();

            // Create x amount of lists to hold cargo 
            var cargoContainers = CreateCargoContainers(numberOfColumns);

            // Add cargo to correct list
            AddCargoToContainers(cargoContainers, inputData.Take(cargoRowsIndex).ToArray());

            // Add all actions to list
            
            RearrangeCargo(cargoContainers, inputData.Skip(firstEmptyLineIndex + 1).ToArray());

            var result = string.Join(string.Empty, cargoContainers.Select(sublist => sublist.First()).ToList());
            Console.WriteLine(result);
        }

        // Exactly the same as Puzzle One, only exception that in P2 i send in Reverse: False in RearrangeCargo
        private static void PuzzleTwo(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");

            var firstEmptyLineIndex = Array.FindIndex(inputData, string.IsNullOrWhiteSpace);
            var cargoRowsIndex = firstEmptyLineIndex - 1;
            var numberOfColumns = inputData[cargoRowsIndex].Replace(" ", string.Empty).Select(x => int.Parse(x.ToString())).Count();

            // Create x amount of lists to hold cargo 
            var cargoContainers = CreateCargoContainers(numberOfColumns);

            // Add cargo to correct list
            AddCargoToContainers(cargoContainers, inputData.Take(cargoRowsIndex).ToArray());

            // Add all actions to list

            RearrangeCargo(cargoContainers, inputData.Skip(firstEmptyLineIndex + 1).ToArray(), false);

            var result = string.Join(string.Empty, cargoContainers.Select(sublist => sublist.First()).ToList());
            Console.WriteLine(result);
        }
    }
    
}
