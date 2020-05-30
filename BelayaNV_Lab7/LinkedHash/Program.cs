using System;
using System.Diagnostics;

namespace LinkedHash
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				bool stillContinue = true;
				while (stillContinue)
				{
					#region base_operations
					Console.WriteLine("Hash table operations:\n[1]-Basic operations (add, get); [2]-Search speed test; [3]-Exit\nInput:");
					ConsoleKey response;

					/* get response */
					do
					{
						response = Console.ReadKey(true).Key;
						//if (response != ConsoleKey.Enter)
						//	Console.WriteLine();

					}
					while (response != ConsoleKey.D1 && response != ConsoleKey.D2 && response != ConsoleKey.D3);
					#endregion

					#region basic_operations_showcase
					if (response == ConsoleKey.D1)
					{
						bool loop1 = true;

						// checking for 100
						long size = 100; // tested array size
						HashTable hash_table = new HashTable(size);

						Console.WriteLine("Basic operations selected.");
						while (loop1)
						{
							Console.WriteLine("[1]-Add, [2]-Get, [3]-print, [4]-go back.\nInput:");
							do
							{
								response = Console.ReadKey(true).Key;
								//if (response != ConsoleKey.Enter)
								//	Console.WriteLine();

							}
							while (response != ConsoleKey.D1 && response != ConsoleKey.D2 && response != ConsoleKey.D3 && response != ConsoleKey.D4);

							switch (response)
							{
								case ConsoleKey.D1:
									{
										Console.Write("Enter integer value:");
										hash_table.Add(long.Parse(Console.ReadLine()));
										Console.WriteLine("Done");
										break;
									}
								case ConsoleKey.D2:
									{
										Console.Write("Enter key:");
										long k = long.Parse(Console.ReadLine());
										if(k>=size)
										{
											Console.WriteLine("Invalid key (test array size = 30)");
											break;
										}
										Console.Write("Value: ");
										hash_table.PrintValue(k);
										break;
									}
								case ConsoleKey.D3:
									{
										Console.WriteLine("Hash table:");
										hash_table.PrintTable();
										break;
									}
								default:
									{
										Console.WriteLine("Goig back...");
										loop1 = false;
										break;
									}
							}


						}
					}
					#endregion

					#region speeeeeed_tests
					else if (response == ConsoleKey.D2)
					{
						Console.WriteLine("Speed test selected.");
						bool loop2 = true;

						while (loop2)
						{
							Console.WriteLine("Select table size:[1]- 1 000, [2]- 10 000, [3]- 100 000, [4]- 1 000 000, [5]- go back");

							do
							{
								response = Console.ReadKey(true).Key;
							}
							while (response != ConsoleKey.D1 && response != ConsoleKey.D2 && response != ConsoleKey.D3 && response != ConsoleKey.D4 && response != ConsoleKey.D5);

							if (response == ConsoleKey.D5) // leave now
							{
								loop2 = false;
								continue;
							}

							int size = 1000; // d1 case

							if (response == ConsoleKey.D2)
								size = 10000;
							else if (response == ConsoleKey.D3)
								size = 100000;
							else if (response == ConsoleKey.D4)
								size = 1000000;

							HashTable hash_table = new HashTable(size);
							Random rand = new Random();
							Stopwatch timer = new Stopwatch();

							timer.Start();
							for (int i = 0; i < 100; i++) // 0 to 100
							{
								hash_table.Add(rand.Next(0, 1000));
							}
							timer.Stop();

							long first_100 = timer.ElapsedTicks; // 0-100 time

							int second_interval = size - 100;
							
							for (int i = 100; i < second_interval; i++) // 100 to x-100
							{
								hash_table.Add(rand.Next(0, 1000));
							}

							timer.Restart();
							for (int i = second_interval; i < size; i++) // x-100 to x
							{
								hash_table.Add(rand.Next(0, 1000));
							}
							timer.Stop();

							long last_100 = timer.ElapsedTicks; // x-100 to x time
							// search time
							timer.Restart();
							hash_table.PrintValueSilent(rand.Next(0, 1000));
							timer.Stop();

							long search_time = timer.ElapsedTicks;
							Console.WriteLine($"\nTime (ticks):\n[0 to 100 time]: {first_100}; [{size-100} to {size} time]: {last_100}; [Search_time]: {search_time}\n");
						}
					}
					#endregion

					/* exit sequence */
					else if (response == ConsoleKey.D3)
					{
						Console.WriteLine("Leaving...");
						stillContinue = false; // kinda redundant, could just go with return;
					}

				}
				
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception caugth" + e.Message);
			}
		}
	}
}
