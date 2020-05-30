using System;
namespace Graph
{
	class Graph
	{
		private uint vertices;
		//private uint edges;
		private int[,] AdjacencMatrix; // this turns simple graph into oriented one, whick is used in both cases, while carying both bandwidth and orientation

		public Graph(uint vertices, uint edges, uint[,] connections, bool IsFirstTask)
		{
			this.vertices = vertices;
			//this.edges = edges;
			AdjacencMatrix = new int[vertices, vertices];
			for (int i = 0; i < vertices; i++)
			{
				int j = 0;
				while (connections[i, j] != 0 && j < edges)
				{
					AdjacencMatrix[i, connections[i, j] - 1] = 1;
					AdjacencMatrix[connections[i, j] - 1, i] = 1;
					j++;
				}
				if (!IsFirstTask)
				{
					AdjacencMatrix[i, i] = 1;
				}
			}
		}

		// i realise now that this is redundant, but i'm too far gone to care at this point
		public Graph(uint vertices, uint[,] connections, bool IsFirstTask)
		{
			this.vertices = vertices;
			AdjacencMatrix = new int[vertices, vertices];
			for (int i = 0; i < vertices; i++)
			{
				int j = 0;
				while (connections[i, j] != 0)
				{
					AdjacencMatrix[i, connections[i, j] - 1] = 1;
					AdjacencMatrix[connections[i, j] - 1, i] = 1;
					j++;
				}
				if (!IsFirstTask)
				{
					AdjacencMatrix[i, i] = 1;
				}
			}
		}


		// testing output
		public void OutputAdjacent()
		{
			for (int i = 0; i < vertices; i++)
			{
				for (int j = 0; j < vertices; j++)
				{
					Console.Write(AdjacencMatrix[i, j] + " ");
				}
				Console.WriteLine();
			}
		}

		public int[,] GetAdjacentMatrix() => AdjacencMatrix;

	}
}