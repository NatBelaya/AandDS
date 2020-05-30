using System;

namespace D_ary_heap
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.Write("Ternary heap:\nInput heap size:");
				int size = int.Parse(Console.ReadLine());
				if (size <= 0)
				{
					throw new Exception("Invalid heap size");
				}
				TernaryHeap heap = new TernaryHeap(size);

				int value;
				ConsoleKey condition, operation;
				do
				{
					Console.WriteLine("\nTernary Heap Operations");
					Console.WriteLine("1. Insert\n2. Delete\n3. Check full\n4. Check empty\n5. Clear");

					Console.WriteLine("Your Choice:");
					do
					{
						operation = Console.ReadKey(true).Key;
					}
					while (operation != ConsoleKey.D1 && operation != ConsoleKey.D2 && operation != ConsoleKey.D3 && operation != ConsoleKey.D4 && operation != ConsoleKey.D5);

					switch (operation)
					{
						case ConsoleKey.D1:
							{ 
							Console.Write("Enter integer element to insert: ");
							value = int.Parse(Console.ReadLine());
							heap.Insert(value);
							break;
							}
						case ConsoleKey.D2:
							{
								Console.Write("Enter delete position: ");
								value = int.Parse(Console.ReadLine());
								heap.Delete(value - 1);
								break;
							}
						case ConsoleKey.D3:
							{ 
							if (heap.isFull())
								Console.WriteLine("The Heap is Full");
							else
								Console.WriteLine("The Heap is not Full");
							break;
							}
						case ConsoleKey.D4:
							{ 
							if (heap.isEmpty())

								Console.WriteLine("The Heap is Empty");
							else
								Console.WriteLine("The Heap is not Empty");
							break;
							}
						case ConsoleKey.D5:
							{ 
							heap.Empty();
							Console.WriteLine("Heap Cleared");
							break;
							}
					}
					heap.print("",0,false);
					//heap.PrintHeap();
					Console.WriteLine("\nDo you want to continue (Type y or n):");
					do
					{
						condition = Console.ReadKey(true).Key;
					}
					while (condition != ConsoleKey.Y && condition != ConsoleKey.N);
				}
				while (condition != ConsoleKey.N);

			}

			catch (Exception e)
			{
				Console.WriteLine("Exception caught: " + e.Message);
			}

		}
	}
}