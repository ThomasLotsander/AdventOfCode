using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Helpers;

namespace Hub.Days
{
    internal class Day9 : DefaultDaySetup
    {
        public override async Task Run()
        {
            await Setup(9);
            if (SampleData != null)
            {
                await PuzzleOne(SampleData);
                await PuzzleTwo(SampleData);
            }

            if (RealData != null)
            {
                await PuzzleOne(RealData);
                await PuzzleTwo(RealData);
            }
        }

        public override Task PuzzleOne(string[] inputData)
        {
            throw new NotImplementedException();
        }

        public override Task PuzzleTwo(string[] inputData)
        {
            throw new NotImplementedException();
        }
    }
}
