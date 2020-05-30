using System;
using System.Collections.Generic;

namespace Graph
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Select task: [1] - Max paths, no edges; [2] - Max paths, no verticles");

				ConsoleKey response;
				do
				{
					response = Console.ReadKey(true).Key;
				}
				while (response != ConsoleKey.D1 && response != ConsoleKey.D2);

				bool IsFirstTask = response.Equals(ConsoleKey.D1);

				//Todo: use presets
				Console.WriteLine("Do you want to use presets: Y/N");
				do
				{
					response = Console.ReadKey(true).Key;
				}
				while (response != ConsoleKey.Y && response != ConsoleKey.N);

				uint vertices, edges, u, v;
				uint[,] connections;
				Graph graph;



				#region manual_input
				if (response == ConsoleKey.N)
				{
					Console.Write("Graph vertices amount:");
					vertices = uint.Parse(Console.ReadLine());
					if (vertices < 2)
						throw new Exception("Graph should at least contain 2 vertices");

					Console.Write("Graph edges amount:");
					edges = uint.Parse(Console.ReadLine());
					if (edges > vertices * (vertices - 1) / 2)
						throw new Exception("Far too many edges");


					connections = new uint[vertices, vertices];

					Console.Write("Input starting vertex, (1 to size): ");
					u = uint.Parse(Console.ReadLine());

					Console.Write("Input ending vertex, (1 to size): ");
					v = uint.Parse(Console.ReadLine());

					//List<List<uint>> connections = new List<List<uint>>((int)vertices);
					uint used_edges = 0;
					Console.WriteLine("Now input vertices connected to specified one, starting from 1, sentinel = 0, only use edges once:");
					for (int i = 0; i < vertices && used_edges < edges; i++)
					{
						int j = 0;
						//connections.Add(new List<uint>());
						bool ValidNumber = true;

						while (ValidNumber && used_edges < edges) // todo: null check in the future for the connections[i]
						{
							Console.Write("[{0}]:", i + 1);
							uint entry = uint.Parse(Console.ReadLine());

							if (entry == 0)
							{
								ValidNumber = false;
								continue;
							}
							if (entry == i)
							{
								Console.WriteLine("Graph is not oriented. Cannot make edge from {0} to {0}", i + 1);
								continue;
							}
							//entry--;
							connections[i, j] = entry;
							//connections[i].Add(entry);
							j++;
							used_edges++;
						}

						ValidNumber = true;
					}
					if (used_edges != edges)
						Console.WriteLine("Not all edges used up. Using {0} edges instead of {1}.", used_edges, edges);
					else
						Console.WriteLine("All edges used up.");
					graph = new Graph(vertices, edges, connections, IsFirstTask);
				}
				#endregion

				#region presets_input

				else
				{
					Console.WriteLine("Select a preset:\n[1] - 4x4 square (as simple as it gets);\n[2] - 6x9 hexagon with a lightning bolt inside (1-3-6-5)\n[3] - Pentagon w/ vertix in the middle");
					do
					{
						response = Console.ReadKey(true).Key;
					}
					while (response != ConsoleKey.D1 && response != ConsoleKey.D2 && response != ConsoleKey.D3);

					if (response == ConsoleKey.D1)
					{
						vertices = 4;
						edges = 4;
						connections = new uint[4, 4]
						{
							{2,0,0,0 },
							{3,0,0,0 },
							{4,0,0,0 },
							{1,0,0,0 }
						};
					}
					else if (response == ConsoleKey.D2)
					{
						vertices = 6;
						edges = 9;
						connections = new uint[6, 6]
						{
							{2,3,6,0,0,0 },
							{1,3,0,0,0,0 },
							{1,2,4,6,0,0 },
							{3,5,6,0,0,0 },
							{4,6,0,0,0,0 },
							{1,3,4,5,0,0 }
						};
					}
					else
					{
						vertices = 6;
						edges = 10;
						connections = new uint[6, 6]
						{
							{2,5,6,0,0,0 },
							{1,3,6,0,0,0 },
							{2,4,6,0,0,0 },
							{3,5,6,0,0,0 },
							{4,1,6,0,0,0 },
							{1,2,3,4,5,0 }
						};
					}
				}
				graph = new Graph(vertices, connections, IsFirstTask); // also, with this one I don't have to worry about repeating edges

				Console.Write("Input starting point, (1 to size): ");
				u = uint.Parse(Console.ReadLine());

				Console.Write("Input ending point, (1 to size): ");
				v = uint.Parse(Console.ReadLine());

				#endregion
				GraphFlow flow = new GraphFlow(graph.GetAdjacentMatrix(), (int)vertices);
				Console.WriteLine("Result: {0}", flow.MaxFlow((int)u - 1, (int)v - 1));
				Console.ReadKey(true);
			}
			catch (Exception e)
			{
				Console.WriteLine("Program fault detected: " + e.Message + "\n" + e.StackTrace);
			}

		}
	}
}

// manual input is more strict

// test subjects:
/*
				uint vertices = 6, edges = 6;
				uint[,] connections = new uint[6, 9]
				{
					{2,3,6,0,0,0,0,0,0 },
					{3,0,0,0,0,0,0,0,0 },
					{4,6,0,0,0,0,0,0,0 },
					{5,6,0,0,0,0,0,0,0 },
					{6,0,0,0,0,0,0,0,0 },
					{0,0,0,0,0,0,0,0,0 },
				};

				Graph graph = new Graph(vertices, edges, connections);
				graph.OutputAdjacent();
				GraphFlow flow = new GraphFlow(graph.GetAdjacentMatrix(), (int)vertices);
				Console.WriteLine("Result: {0}", flow.MaxFlow(0, 3));
				*/