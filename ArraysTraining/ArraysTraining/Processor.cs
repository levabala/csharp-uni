using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysTraining
{
    class Processor
    {
        private Func<int[], int[]> processFunc;
        public Processor(Func<int[], int[]> processFunc)
        {
            this.processFunc = processFunc;
        }

        public int[] process(int[] input)
        {
            return processFunc(input);
        }
    }
}
