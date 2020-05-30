using System;


namespace No1
{
    class No1
    {
        static void Main(string[] args)
        {
            ProblemSolver m = new ProblemSolver();
            int[] input = DataReader.getInput();
            int start = 0;
            int end = input.Length - 1;
            Result result = m.maxProfit(input, start, end);
            if (result.profit > 0)
                Console.WriteLine($"Maximum Profit: {result.profit}, buy date index: {result.buyDateIndex}, sell date index: {result.sellDateIndex}");
            else
                Console.WriteLine("No profit found");
        }
    }
}
