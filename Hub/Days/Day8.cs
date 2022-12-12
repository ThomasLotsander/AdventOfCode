using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Helpers;

namespace Hub.Days
{
    public static class Day8
    {
        public static async Task Run(int day)
        {
            Console.WriteLine($"\n--- Day {day} --- \n");

            var sampleData = await InputDataHelper.GetTestData(FileNameHelper.GetSampleDataFileName(day));
            var realData = await InputDataHelper.GetRealData(FileNameHelper.GetRealFileName(day));

            //PuzzleOne(realData);
            //PuzzleOne(sampleData);
            //PuzzleTwo(sampleData);

            PuzzleTwo(realData);
        }

        private static int[,] CreateForrestGrid(string[] input)
        {
            var grid = new int[input.Length, input[0].Length];
            for (int row = 0; row < input.Length; row++)
            {
                for (int column = 0; column < input[row].Length; column++)
                {
                    var treeHeight = int.Parse(input[row][column].ToString());
                    grid[row, column] = treeHeight;
                }
            }

            return grid;
        }

        private static void CountVisibleTreesFromOutside(int[,] grid)
        {
            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);

            var outerTrees = rows + rows + columns + columns - 4;
            var visibleTrees = 0;

            for (int row = 1; row < rows - 1; row++)
            {
                var currentRow = Enumerable.Range(0, columns)
                    .Select(x => grid[row, x])
                    .ToArray();

                for (int column = 1; column < columns - 1; column++)
                {
                    var height = grid[row, column];

                    var currentColumn = Enumerable.Range(0, rows)
                        .Select(x => grid[x, column])
                        .ToArray();

                    var isVisibleFromSide = IsVisibleFromOutside(height, currentRow, column);
                    var isVisibleFromTopOrBottom = IsVisibleFromOutside(height, currentColumn, row);

                    if (isVisibleFromSide || isVisibleFromTopOrBottom)
                    {
                        visibleTrees++;
                    }
                }
            }

            Console.WriteLine(outerTrees + visibleTrees);
        }

        private static bool IsVisibleFromOutside(int treeHeight, int[] row, int index)
        {
            var isVisible =
                row.Take(index).All(x => x < treeHeight) ||
                row.Skip(index + 1).All(x => x < treeHeight);

            return isVisible;
        }

        private static void CountVisibleTreesFromTreeHouse(int[,] grid)
        {
            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);
            var scenicScore = 0;

            for (int row = 1; row < rows - 1; row++)
            {
                var currentRow = Enumerable.Range(0, columns)
                    .Select(x => grid[row, x])
                    .ToArray();

                for (int column = 1; column < columns - 1; column++)
                {
                    var visibleCount = 1;
                    var height = grid[row, column];

                    var currentColumn = Enumerable.Range(0, rows)
                        .Select(x => grid[x, column])
                        .ToArray();

                    visibleCount *= CountVisibleTreesFromTreeHouse(height, currentRow, column);
                    visibleCount *= CountVisibleTreesFromTreeHouse(height, currentColumn, row);
                    if (visibleCount > scenicScore)
                    {
                        scenicScore = visibleCount;
                    }
                }
            }

            Console.WriteLine(scenicScore);
        }

        private static int CountVisibleTreesFromTreeHouse(int treeHeight, int[] row, int index)
        {
            int leftOrUp = 0;
            int rightOrDown = 0;

            // LEFT && Up
            for (int i = index - 1; i >= 0; i--)
            {
                if (row[i] >= treeHeight)
                {
                    leftOrUp++;
                    break;
                }

                leftOrUp++;
            }


            // Right && Down
            for (int i = index + 1; i < row.Length; i++)
            {
                if (row[i] >= treeHeight)
                {
                    rightOrDown++;
                    break;
                }

                rightOrDown++;
            }

            return leftOrUp * rightOrDown;
        }

        private static void PuzzleOne(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 1 ---");
            var grid = CreateForrestGrid(inputData);
            CountVisibleTreesFromOutside(grid);



        }

        private static void PuzzleTwo(string[] inputData)
        {
            Console.WriteLine("--- Puzzle 2 ---");
            var grid = CreateForrestGrid(inputData);
            CountVisibleTreesFromTreeHouse(grid);
        }
    }
}
