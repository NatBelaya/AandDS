using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1
{
    public class Result
    {
        internal int profit = 0;
        internal readonly int buyDateIndex;
        internal readonly int sellDateIndex;
        public Result(int profit, int buyDateIndex, int sellDateIndex)
        {
            this.profit = profit;
            this.buyDateIndex = buyDateIndex;
            this.sellDateIndex = sellDateIndex;
        }
    }
}
