namespace Graph
{
	class GraphFlow
	{
		static readonly int maxvertices = 40;

		int NUM_VERTICES;    // vertices in graph
		int INFINITY = 10000; // semantics

		int[,] f;  // f[i][j] - flow from i to j
		int[,] c;  // c[i][j] - max flow of (i,j)

		// additional variable for FindPath - breadth-first search
		int[] Flow = new int[maxvertices];  // Flow - flow value through the verticle on current step 
		int[] Link = new int[maxvertices];  // Link[i] stores preious verticle of i -> source
		int[] Queue = new int[maxvertices]; // queue
		int QP, QC;              // QP - queue start, QC - queue element count

		public GraphFlow(int[,] array, int verticles)
		{
			c = array;
			f = new int[verticles, verticles];
			NUM_VERTICES = verticles;
		}

		private int FindPath(int source, int target)
		{
			QP = 0;
			QC = 1;
			Queue[0] = source;
			Flow = new int[maxvertices];
			Link[target] = -1;

			int i;
			int CurVertex;
			Flow[source] = INFINITY;
			while (Link[target] == -1 && QP < QC)
			{
				CurVertex = Queue[QP];
				for (i = 0; i < NUM_VERTICES; i++)
					if ((c[CurVertex, i] - f[CurVertex, i]) > 0 && Flow[i] == 0)
					{
						Queue[QC] = i;
						QC++;
						Link[i] = CurVertex;
						if (c[CurVertex, i] - f[CurVertex, i] < Flow[CurVertex])
							Flow[i] = c[CurVertex, i];
						else
							Flow[i] = Flow[CurVertex];
					}
				QP++;
			}

			if (Link[target] == -1)
				return 0;
			CurVertex = target;
			while (CurVertex != source)
			{
				f[Link[CurVertex], CurVertex] += Flow[target];
				CurVertex = Link[CurVertex];
			}
			return Flow[target];
		}

		// main fuction of max flow
		public int MaxFlow(int source, int target) 
		{
			int MaxFlow = 0;
			int AddFlow;
			do
			{
				AddFlow = FindPath(source, target);
				MaxFlow += AddFlow;
			} while (AddFlow > 0);
			return MaxFlow;
		}
	}
}
