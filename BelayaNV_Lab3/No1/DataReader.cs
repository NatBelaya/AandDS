using System;
using System.IO;

namespace No1
{
    public static class DataReader
    {
        public static int[] getInput()
        {
            string sData = File.ReadAllText("input1.txt");
            string[] split = sData.Split(new char[] { ' ' });
            int[] prices = new int[split.Length];
            int i = 0;
            try {
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                        int.TryParse(s, out prices[i]);                        
                    i++;
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Invalid input");
            }            
            return prices;
        }
    }
}
