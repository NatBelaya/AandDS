using System;

namespace BinarySearchTreeImplementation
{
	class Program
	{
		static void Main(string[] args)
		{
			BinaryTree binaryTree = new BinaryTree();
			Random random = new Random();
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("Random initial tree");
			for (int i = 0; i < 35; i++)
			{
				binaryTree.Add(random.Next(-50, 150));
				//binaryTree.Add(random.Next(0, 4)); // task testing values

			}

			bool continue_working = true;
			binaryTree.PrintTree();
			Console.WriteLine("Warning: press 0 twice to exit");
			Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			do
			{
				Console.WriteLine("\n1)Add element\n2)Search for element\n3)Delete element\n4)Node Height\n5)Node Depth\n6)Node Level\n7)Go Throught\n8)Print\n9)Task\nR)Renew Tree\nC)Clear Tree\n0)Exit\n");
				Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
				ConsoleKey response;
				do
				{
					response = Console.ReadKey(true).Key;
				}

				while (response != ConsoleKey.D1 && response != ConsoleKey.D2 && response != ConsoleKey.D3 &&
				response != ConsoleKey.D4 && response != ConsoleKey.D5 && response != ConsoleKey.D6 &&
				response != ConsoleKey.D7 && response != ConsoleKey.D8 && response != ConsoleKey.D9 &&
				response != ConsoleKey.D0 && response != ConsoleKey.R && response != ConsoleKey.C);
				int value = 0;

				switch (response)
				{
					case ConsoleKey.D1:
						do
						{
							Console.Write("Input valid element: ");
						} while (!int.TryParse(Console.ReadLine(), out value));
						binaryTree.Add(value);
						break;

					case ConsoleKey.D2:
						Console.Write("Looking for: ");
						while (!int.TryParse(Console.ReadLine(), out value)) ;

						Node found = binaryTree.Find(value);
						if (found == null)
							Console.WriteLine("No element found");
						else
							Console.WriteLine("Found");
						break;

					case ConsoleKey.D3:
						Console.WriteLine("1) Right\n2) Left");
						do
						{
							response = Console.ReadKey(true).Key;
						}
						while (response != ConsoleKey.D1 && response != ConsoleKey.D2);

						Console.Write("Delete what: ");
						while (!int.TryParse(Console.ReadLine(), out value)) ;
						if (response == ConsoleKey.D1)
							binaryTree.Delete(value, true);

						else binaryTree.Delete(value, false);

						binaryTree.PrintTree();
						break;

					case ConsoleKey.D4:
						Console.Write("Node Height, select node (value): ");
						while (!int.TryParse(Console.ReadLine(), out value)) ;
						int height = binaryTree.GetHeight(value);
						if (height != -1)
							Console.WriteLine("Height: " + height);
						break;

					case ConsoleKey.D5:
						Console.Write("Node Depth, select node (value): ");
						while (!int.TryParse(Console.ReadLine(), out value)) ;
						int depth = binaryTree.GetDepth(value);
						if (depth != -1)
							Console.WriteLine("Depth: " + depth);
						break;

					case ConsoleKey.D6:
						Console.Write("Node Level, select node (value): ");
						while (!int.TryParse(Console.ReadLine(), out value)) ;
						int level = binaryTree.GetLevel(value);
						if (level != -1)
							Console.WriteLine("Level: " + level);
						break;

					case ConsoleKey.D7:
						Console.WriteLine("1)Forwards\n2)Backwards\n3)Symmetrical");
						do
						{
							response = Console.ReadKey(true).Key;
						}
						while (response != ConsoleKey.D1 && response != ConsoleKey.D2 && response != ConsoleKey.D3);

						Console.WriteLine();
						if (response == ConsoleKey.D1)
						{
							binaryTree.Print(1);
						}
						else if (response == ConsoleKey.D2)
						{
							binaryTree.Print(2);
						}
						else
							binaryTree.Print(3);
						break;

					case ConsoleKey.D8:
						binaryTree.PrintTree();
						break;

					case ConsoleKey.D9:
						Console.WriteLine("Find and remove (right delete) average (arithmetic mean) node, whose right subtree has one less/one more node. \nGo through (PreOrder) resulting tree.\n");
						binaryTree.Task();
						//Console.WriteLine("Task: " + binaryTree.task());
						break;

					case ConsoleKey.R:
						Console.Write("Tree size:");
						while (!int.TryParse(Console.ReadLine(), out value)) ;
						if (value <= 0)
						{
							Console.WriteLine("Invalid tree size");
							break;
						}

						binaryTree = new BinaryTree();
						for (int i = 0; i < value; i++)
							binaryTree.Add(random.Next(-150, 150));
						Console.WriteLine("Tree renewed");
						break;

					case ConsoleKey.C:
						binaryTree = new BinaryTree();
						Console.WriteLine("Tree Cleared");
						break;

					case ConsoleKey.D0:
						continue_working = false;
						break;
				}
				Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

			} while (continue_working);
			Console.ReadKey(true);
		}
	}
}