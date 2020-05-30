using System.IO;
using System;


namespace No2
{
    class DataReader
    {
        public static bool getInput(string path, ref int[]values, ref int[] amounts)
        {
            string[] sData = File.ReadAllLines(path);
            string[] valueSplit = sData[0].Split(new char[] { ' ' });
            string[] amountSplit = sData[1].Split(new char[] { ' ' });
            if(valueSplit.Length != amountSplit.Length)
            {
                Console.WriteLine("Invalid Input: inconsistency in input (amount of values and ... amounts)");
                return false;
            }

            values = new int[valueSplit.Length];
            amounts = new int[amountSplit.Length];
            int i = 0;
            try
            {
                foreach (string s in valueSplit)
                {
                    if (s.Trim() != "")
                    {
                        int.TryParse(s, out values[i]);
                        if (values[i] < 0)
                            throw new IOException();
                        i++;
                    }
                    else
                        throw new IOException();
                }

                i = 0;
                foreach (string s in amountSplit)
                {
                    if (s.Trim() != "")
                    {
                        int.TryParse(s, out amounts[i]);
                        if (amounts[i] < 0)
                            throw new IOException();
                        i++;
                    }
                    else
                        throw new IOException();
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Invalid input");
                return false;
            }
            
            return true;
        }
    }
}
