namespace No1
{
    public class ProblemSolver
    {
        public Result maxProfit(int[] prices, int start, int end)
        {
            if (start >= end)
            {
                return new Result(0, 0, 0);
            }
            int mid = start + (end - start) / 2;

            Result leftResult = maxProfit(prices, start, mid);
            Result rightResult = maxProfit(prices, mid + 1, end);

            int minLeftIndex = getMinIndex(prices, start, mid);
            int maxRightIndex = getMaxIndex(prices, mid, end);

            int centerProfit = prices[maxRightIndex] - prices[minLeftIndex];
            if (centerProfit > leftResult.profit && centerProfit > rightResult.profit)
            {
                return new Result(centerProfit, minLeftIndex, maxRightIndex);
            }
            else if (leftResult.profit > centerProfit && rightResult.profit > centerProfit)
            {
                return leftResult;
            }
            else
            {
                return rightResult;
            }
        }

        public int getMinIndex(int[] A, int i, int j)
        {
            int min = i;
            for (int k = i + 1; k <= j; k++)
            {
                if (A[k] < A[min])
                    min = k;
            }
            return min;
        }

        public int getMaxIndex(int[] A, int i, int j)
        {
            int max = i;
            for (int k = i + 1; k <= j; k++)
            {
                if (A[k] > A[max])
                    max = k;
            }
            return max;
        }
    }

}
