using System;

namespace BinarySearchTreeImplementation
{
	enum NodePosition
	{
		left,
		right,
		center
	}

	class Node
	{
		public int Value;
		public Node LeftNode { get; set; }
		public Node RightNode { get; set; }
		public Node Parent { get; set; }

		public Node(int data)
		{
			Value = data;
		}

		private void PrintValue(string value, NodePosition nodePostion)
		{
			switch (nodePostion)
			{
				case NodePosition.left:
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.Write("L:");
					PrintValue(value);
					break;
				case NodePosition.right:
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write("R:");
					PrintValue(value);
					break;
				case NodePosition.center:
					Console.WriteLine(value);
					break;
				default:
					throw new NotImplementedException();
			}
		}

		private void PrintValue(string value)
		{
			Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
			Console.WriteLine(value);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public void Print(string indent, NodePosition nodePosition, bool end_level, bool empty)
		{
			Console.Write(indent);
			if (end_level)
			{
				Console.Write("\u2514\u2500");
				indent += "  ";
			}
			else
			{
				Console.Write("\u251C\u2500");
				indent += "\u2502 ";
			}

			var stringValue = empty ? "-" : Value.ToString();
			PrintValue(stringValue, nodePosition);

			if (!empty && (LeftNode != null || RightNode != null))
			{
				if (LeftNode != null)
					LeftNode.Print(indent, NodePosition.left, false, false);
				else
					Print(indent, NodePosition.left, false, true);

				if (RightNode != null)
					RightNode.Print(indent, NodePosition.right, true, false);
				else
					Print(indent, NodePosition.right, true, true);
			}
		}
	}
}