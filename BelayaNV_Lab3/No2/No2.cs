using System;
using System.Collections.Generic;
using System.Linq;

namespace No2
{
	class CoinChangeProblem
	{
		public static int[] client_values = { };
		public static int[] client_amounts = { };
		public static int[] vendor_values = { };
		public static int[] vendor_amounts = { };
		public static List<List<int>> NoChangeWays = new List<List<int>>();
		public static List<List<int>> ChangeWays = new List<List<int>>();
		public static List<List<int>> NoChangeWaysVendor = new List<List<int>>();

		public static int cur_pos = 0; // definetly could do without this one, maybe later

		static void Main(string[] args)
		{
			Console.WriteLine("Coin change problem:\n1)Use preset\n2)Manual input\n");

			#region input

			ConsoleKey response;

			do
			{
				response = Console.ReadKey(true).Key;
			}
			while (response != ConsoleKey.D1 && response != ConsoleKey.D2);

			if (response == ConsoleKey.D1)
			{
				#region file_input

				if (!DataReader.getInput("../../../No2_Preset/input2_client.txt", ref client_values, ref client_amounts))
				{
					Console.WriteLine("Error reading client data");
					return;
				}


				if (!DataReader.getInput("../../../No2_Preset/input2_vendor.txt", ref vendor_values, ref vendor_amounts))
				{
					Console.WriteLine("Error reading vendor data");
					return;
				}
				#endregion

				PrintClientValues();

				PrintVendorValues();
			}

			else
			{
				#region manual_client

				int count = 0;
				do
					Console.Write("How many types of coins are there for the client:");
				while (!int.TryParse(Console.ReadLine(), out count) && count <= 0);

				client_values = new int[count];
				client_amounts = new int[count];

				Console.WriteLine("Input {0} client coin values", count);
				int value = 0;
				for (int i = 1; i <= count; i++)
				{
					do
						Console.Write("[{0}]:", i);
					while (!int.TryParse(Console.ReadLine(), out value) && value <= 0);
					client_values[i - 1] = value;
				}
				Console.WriteLine("Input {0} client coin amounts", count);
				for (int i = 1; i <= count; i++)
				{
					do
						Console.Write("[{0}]:", count);
					while (!int.TryParse(Console.ReadLine(), out value) && value <= 0);
					client_amounts[i - 1] = value;
				}
				#endregion

				#region manaul_vendor

				do
					Console.Write("How many types of coins are there for the vendor:");
				while (!int.TryParse(Console.ReadLine(), out count) && count <= 0);

				vendor_values = new int[count];
				vendor_amounts = new int[count];

				Console.WriteLine("Input {0} vendor coin values", count);
				for (int i = 1; i <= count; i++)
				{
					do
						Console.Write("[{0}]:", i);
					while (!int.TryParse(Console.ReadLine(), out value) && value <= 0);
					vendor_values[i - 1] = value;
				}
				Console.WriteLine("Input {0} vendor coin amounts", count);
				for (int i = 1; i <= count; i++)
				{
					do
						Console.Write("[{0}]:", count);
					while (!int.TryParse(Console.ReadLine(), out value) && value <= 0);
					vendor_amounts[i - 1] = value;
				}
				Console.WriteLine();
				#endregion

				PrintClientValues();

				PrintVendorValues();
			}

			#endregion

			int price = 0;
			do
				Console.Write("Customer has to pay $:");
			while (!int.TryParse(Console.ReadLine(), out price) && price <= 0);

			GetResults(price);
			Console.ReadKey(true);
		}


		/* Function to find the total number of distinct ways to get change of `Price` from limited supply `CoinAmounts` of coins in set `CoinSet` */
		/* used by client and vendor */
		private static int CountWaysNoChange(int[] CoinSet, int[] CoinAmounts, int CurrentAmount, int CoinNum, int Price, bool IsClient)
		{
			/* if total is 0, return 1 (solution found) */
			if (Price == 0)
			{
				if (IsClient)
				{
					NoChangeWays.Add(new List<int>(NoChangeWays[NoChangeWays.Count - 1]));
					NoChangeWays[NoChangeWays.Count - 1].RemoveAt(NoChangeWays[NoChangeWays.Count - 1].Count - 1);

				}
				else
				{
					NoChangeWaysVendor.Add(new List<int>(NoChangeWaysVendor[NoChangeWaysVendor.Count - 1]));
					NoChangeWaysVendor[NoChangeWaysVendor.Count - 1].RemoveAt(NoChangeWaysVendor[NoChangeWaysVendor.Count - 1].Count - 1);
				}
				return 1;
			}

			/* return 0 (solution do not exist) if total become negative or no elements are left to be used */
			if (CoinNum > 0 && CurrentAmount == 0 && Price > 0) // if price>0 but the current coin type was depleted
			{
				CoinNum -= 1;
				CurrentAmount = CoinAmounts[CoinNum];
			}

			else if (Price < 0 || CoinNum < 0 || CurrentAmount == 0)
			{
				if (IsClient)
				{
					if (NoChangeWays[NoChangeWays.Count - 1].Count != 0)
						NoChangeWays[NoChangeWays.Count - 1].RemoveAt(NoChangeWays[NoChangeWays.Count - 1].Count - 1); // remove 1 excessive coin
					else // remove new excessive array
					{
						NoChangeWays.RemoveAt(NoChangeWays.Count - 1);
					}
				}
				else
				{
					if (NoChangeWaysVendor[NoChangeWaysVendor.Count - 1].Count != 0)
						NoChangeWaysVendor[NoChangeWaysVendor.Count - 1].RemoveAt(NoChangeWaysVendor[NoChangeWaysVendor.Count - 1].Count - 1); // remove 1 excessive coin
					else // remove new excessive array
					{
						NoChangeWaysVendor.RemoveAt(NoChangeWaysVendor.Count - 1);
					}
				}
				return 0;
			}
			else { }

			/* Case 1. include current coin S[n] in solution and recur with remaining change (N - S[n]) with same type of coin and one less coin of that type */
			if (IsClient)
				NoChangeWays[NoChangeWays.Count - 1].Add(CoinSet[CoinNum]);
			else
				NoChangeWaysVendor[NoChangeWaysVendor.Count - 1].Add(CoinSet[CoinNum]);

			int incl = CountWaysNoChange(CoinSet, CoinAmounts, CurrentAmount - 1, CoinNum, Price - CoinSet[CoinNum], IsClient);

			/* Case 2. exclude current coin S[n] from solution and recur for remaining coins (n - 1) */

			int excl;
			if (CoinNum != 0)
				excl = CountWaysNoChange(CoinSet, CoinAmounts, CoinAmounts[CoinNum - 1], CoinNum - 1, Price, IsClient);
			else
				excl = CountWaysNoChange(CoinSet, CoinAmounts, CoinAmounts[CoinNum], CoinNum - 1, Price, IsClient); // so that it doesn't throw an exception

			/* return total ways by including or excluding current coin */
			return incl + excl;
		}

		/* same idea as above, but this time count and store excessive payments (pretty much the opposite task) */
		/* used by the client only */
		private static int CountWaysWithChange(int[] CoinSet, int[] CoinAmounts, int CurrentAmount, int CoinNum, int Price)
		{
			if (CoinNum > 0 && CurrentAmount == 0 && Price > 0) // if price>0 but the current coin type was depleted
			{
				CoinNum -= 1;
				CurrentAmount = CoinAmounts[CoinNum];
			}

			if (Price < 0)
			{
				ChangeWays.Add(new List<int>(ChangeWays[ChangeWays.Count - 1]));
				ChangeWays[ChangeWays.Count - 1].RemoveAt(ChangeWays[ChangeWays.Count - 1].Count - 1);
				return 1;
			}

			if (Price == 0 || CoinNum < 0 || CurrentAmount <= 0)
			{
				if (ChangeWays[ChangeWays.Count - 1].Count != 0)
					ChangeWays[ChangeWays.Count - 1].RemoveAt(ChangeWays[ChangeWays.Count - 1].Count - 1); // remove 1 excessive coin
				else // remove new excessive array
				{
					ChangeWays.RemoveAt(ChangeWays.Count - 1);
				}
				return 0;
			}

			

			ChangeWays[ChangeWays.Count - 1].Add(CoinSet[CoinNum]);
			int incl = CountWaysWithChange(CoinSet, CoinAmounts, CurrentAmount - 1, CoinNum, Price - CoinSet[CoinNum]);


			int excl;
			if (CoinNum != 0)
				excl = CountWaysWithChange(CoinSet, CoinAmounts, CoinAmounts[CoinNum - 1], CoinNum - 1, Price);
			else
				excl = CountWaysWithChange(CoinSet, CoinAmounts, CoinAmounts[CoinNum], CoinNum - 1, Price); // so that it doesn't throw an exception

			return incl + excl;
		}

		public static void PrintClientValues()
		{
			Console.WriteLine("Client values. [Value]:Amount");
			for (int i = 0; i < client_values.Length; i++)
			{
				Console.WriteLine($"[{client_values[i]}]:{client_amounts[i]}");
			}
			Console.WriteLine("\n");
		}

		public static void PrintVendorValues()
		{
			Console.WriteLine("Vendor values. [Value]:Amount");
			for (int i = 0; i < vendor_amounts.Length; i++)
			{
				Console.WriteLine($"[{vendor_values[i]}]:{vendor_amounts[i]}");
			}
			Console.WriteLine("\n");
		}
		
		// driver code
		public static void GetResults(int price)
		{
			// first, check for no change possibilites
			NoChangeWays.Add(new List<int>());

			int no_change_ways_count = CountWaysNoChange(client_values, client_amounts, client_amounts[client_amounts.Length - 1], client_values.Length - 1, price, true); // client version
			if (no_change_ways_count != 0)
			{
				Console.Write("{0} way(s) of paying {1} units.\nLeast coins involved - [{2}] :", no_change_ways_count, price, NoChangeWays[0].Count);
				// the shortest solution is always the first one 
				for (int j = 0; j < NoChangeWays[0].Count; j++)
				{
					Console.Write($" {NoChangeWays[0][j]},");
				}
				Console.Write("\b \n");
			}
			else // check if it's possible for the client to pay the price with change
			{
				// todo here implement the change back
				ChangeWays.Add(new List<int>());
				NoChangeWaysVendor.Add(new List<int>());
				int change_needed_ways = CountWaysWithChange(client_values, client_amounts, client_amounts[client_amounts.Length - 1], client_values.Length - 1, price);
				if (change_needed_ways != 0)
				{
					int[] handed_value = new int[ChangeWays.Count]; // array with max paid values
					for (int i = 0; i < ChangeWays.Count; i++)
					{
						for (int j = 0; j < ChangeWays[i].Count; j++)
						{
							handed_value[i] += ChangeWays[i][j];
						}
					}
					int[] VendorChangeWays = new int[ChangeWays.Count];
					for (int i = 0; i < ChangeWays.Count; i++)
					{
						// vendor version, get amount of ways
						//to return price - handed_value coins value
						VendorChangeWays[i] = CountWaysNoChange(vendor_values, vendor_amounts, vendor_amounts[vendor_amounts.Length - 1], vendor_values.Length - 1, handed_value[i] - price, false);
					}
					if (VendorChangeWays.Length != 0)
					{
						int min_coins = NoChangeWaysVendor[0].Count + ChangeWays[0].Count; // first exceeding option and first change option
						List<int> client_gave = ChangeWays[0]; // coins client gave
						List<int> vendor_gave = NoChangeWaysVendor[0]; // change from vendor
						for (int i = 1; i < VendorChangeWays.Length; i++)
						{
							int temp_val = NoChangeWaysVendor[i].Count + ChangeWays[i].Count;
							if (min_coins > temp_val)
							{
								min_coins = temp_val;
								client_gave = ChangeWays[i];
								vendor_gave = NoChangeWaysVendor[i];
							}
						}
						Console.Write("Vendor had to give out change. Client gave {1} coin(s), Vendor gave {2} coin(s)\nMinimum amount of coins in this transaction is {0}\nClient:", min_coins, client_gave.Count, vendor_gave.Count);
						for (int i = 0; i < client_gave.Count; i++)
						{
							Console.Write(" {0},", client_gave[i]);
						}
						Console.Write("\b \nVendor:");
						for (int i = 0; i < vendor_gave.Count; i++)
						{
							Console.Write(" {0},", vendor_gave[i]);
						}
						Console.Write("\b \n");

					}
					else
						Console.WriteLine("No possible way to pay {0}", price);
				}
				else
				{
					Console.WriteLine("No possible way to pay {0}", price);
				}
			}
		}
	}
}


/*
⣿⣿⣿⣿⣿⣿⣿⡿⡛⠟⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⠿⠨⡀⠄⠄⡘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⠿⢁⠼⠊⣱⡃⠄⠈⠹⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⡿⠛⡧⠁⡴⣦⣔⣶⣄⢠⠄⠄⠹⣿⣿⣿⣿⣿⣿⣿⣤⠭⠏⠙⢿⣿⣿⣿⣿⣿
⣿⡧⠠⠠⢠⣾⣾⣟⠝⠉⠉⠻⡒⡂⠄⠙⠻⣿⣿⣿⣿⣿⡪⠘⠄⠉⡄⢹⣿⣿⣿⣿
⣿⠃⠁⢐⣷⠉⠿⠐⠑⠠⠠⠄⣈⣿⣄⣱⣠⢻⣿⣿⣿⣿⣯⠷⠈⠉⢀⣾⣿⣿⣿⣿
⣿⣴⠤⣬⣭⣴⠂⠇⡔⠚⠍⠄⠄⠁⠘⢿⣷⢈⣿⣿⣿⣿⡧⠂⣠⠄⠸⡜⡿⣿⣿⣿
⣿⣇⠄⡙⣿⣷⣭⣷⠃⣠⠄⠄⡄⠄⠄⠄⢻⣿⣿⣿⣿⣿⣧⣁⣿⡄⠼⡿⣦⣬⣰⣿
⣿⣷⣥⣴⣿⣿⣿⣿⠷⠲⠄⢠⠄⡆⠄⠄⠄⡨⢿⣿⣿⣿⣿⣿⣎⠐⠄⠈⣙⣩⣿⣿
⣿⣿⣿⣿⣿⣿⢟⠕⠁⠈⢠⢃⢸⣿⣿⣶⡘⠑⠄⠸⣿⣿⣿⣿⣿⣦⡀⡉⢿⣧⣿⣿
⣿⣿⣿⣿⡿⠋⠄⠄⢀⠄⠐⢩⣿⣿⣿⣿⣦⡀⠄⠄⠉⠿⣿⣿⣿⣿⣿⣷⣨⣿⣿⣿
⣿⣿⣿⡟⠄⠄⠄⠄⠄⠋⢀⣼⣿⣿⣿⣿⣿⣿⣿⣶⣦⣀⢟⣻⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⡆⠆⠄⠠⡀⡀⠄⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⡿⡅⠄⠄⢀⡰⠂⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
*/

// result test
/*
Console.WriteLine("No Change Ways: " + CountWaysNoChange(client_values, client_amounts, client_amounts[client_amounts.Length - 1], client_values.Length - 1, price));
for (int i = 0; i < NoChangeWays.Count; i++)
{
   Console.Write("No Change Way #{0}:", i + 1);
   for (int j = 0; j < NoChangeWays[i].Count; j++)
   {
	   Console.Write($" {NoChangeWays[i][j]},");
   }
   Console.Write("\b \b\n");
}
Console.WriteLine();
//*/
