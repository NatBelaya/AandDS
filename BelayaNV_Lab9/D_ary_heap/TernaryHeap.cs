using System;

namespace D_ary_heap
{
	class TernaryHeap
	{
		private readonly int d = 3;
		private int currentSize;
		private readonly int size;
		private readonly int[] heap;
		//private readonly Node[] order;

		/* Constructor */
		public TernaryHeap(int capacity)
		{
			currentSize = 0;
			size = capacity + 1;
			heap = new int[capacity + 1];
			//order = new Node[capacity + 1];
			for (int i = 0; i < capacity + 1; i++)
			{
				heap[i] = -1;
				//order[i] = new Node(false, false, -1);
			}
		}


		/* Constructor , filling up heap with a given array */
		public TernaryHeap(int[] array, int kidsAmount)
		{
			int i = 0;
			while (array[i] != -1)
			{
				i++;
				//order[i] = new Node(false, false, array[i]);
			}
			currentSize = i;
			heap = array;
			d = kidsAmount;
			buildHeap();
		}


		/* Check if heap is empty */
		public bool isEmpty()
		{
			return currentSize == 0;
		}


		/* Check if heap is full */
		public bool isFull()
		{
			return currentSize == size;
		}


		/* Clear heap */
		public void Empty()
		{
			currentSize = 0;
		}


		/* Get index parent of i */
		public int parent(int i)
		{
			return (i - 1) / d;
		}


		/* Function to get index of k th child of i */
		public int kthChild(int i, int k)
		{
			return d * i + k;
		}


		/* Function to inset element */
		public void Insert(int x)
		{
			if (isFull())
			{
				Console.WriteLine("Array Out of Bounds");
				return;
			}

			int space = currentSize;
			currentSize++;
			heap[space] = x;
			percolateUp(space); 
		}


		/* Function to find least element */
		private int GetMin()
		{
			if (isEmpty())
			{
				Console.WriteLine("Array Underflow (array is empty)");
				return 0;
			}
			return heap[0];
		}


		/* Function to delete element at an index */
		public int Delete(int space)
		{
			if (isEmpty())
			{
				Console.WriteLine("Array Underflow (array is empty)");
				return 0;
			}

			int keyItem = heap[space];
			heap[space] = heap[currentSize - 1];
			currentSize--;
			percolateDown(space);
			return keyItem;
		}


		/* Function to build heap */
		private void buildHeap()
		{
			for (int i = currentSize - 1; i >= 0; i--)
				percolateDown(i);
		}


		/* Function percolateDown */
		private void percolateDown(int space)
		{
			int child;
			int temp = heap[space];
			for (; kthChild(space, 1) < currentSize; space = child)
			{
				child = SmallestChild(space);
				if (heap[child] < temp)
					heap[space] = heap[child];
				else
					break;
			}
			heap[space] = temp;
		}


		/* Function to get smallest child from all valid indices */
		private int SmallestChild(int space)
		{
			int bestChildYet = kthChild(space, 1);
			int k = 2;
			int candidateChild = kthChild(space, k);
			while ((k <= d) && (candidateChild < currentSize))
			{
				if (heap[candidateChild] < heap[bestChildYet])
					bestChildYet = candidateChild;
				k++;
				candidateChild = kthChild(space, k);
			}
			return bestChildYet;
		}


		/* Function percolateUp */
		private void percolateUp(int space)
		{
			int tmp = heap[space];
			for (; space > 0 && tmp < heap[parent(space)]; space = parent(space))
				heap[space] = heap[parent(space)];
			heap[space] = tmp;
		}


		/* Print heap */
		

		public void print(string str, int n, bool temp)
		{
			if (n < size)
			{
				//System.out.print(str);
				Console.Write(str);
				if (kthChild(n, n) % d == 0)
					Console.WriteLine("  \u2514\u2500(" + heap[n] + ")");
				else
					Console.WriteLine("  \u251C\u2500(" + heap[n] + ")");

				for (int i = 1; i < d; i++)
				{
					if (temp)
						print(str + "  \u2502", d * n + i, true);
					else
						print(str + "   ", d * n + i, true);
				}
				if (temp)
					print(str + "  \u2502", d * n + d, false);
				else
					print(str + "   ", d * n + d, false);
			}
		}

	}
}