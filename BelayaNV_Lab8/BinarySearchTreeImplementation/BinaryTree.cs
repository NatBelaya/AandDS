using System;
using System.Collections.Generic;

namespace BinarySearchTreeImplementation
{
	class BinaryTree
	{
		public Node Root { get; set; }

		public void Add(int value)
		{
			if (Root == null)
			{
				Root = new Node(value);
			}
			else
				AddTo(value, Root);
		}

		private void AddTo(int Value, Node root)
		{
			if (root.Value == Value)
				Console.WriteLine("Repeating value");
			else if (Value < root.Value)
			{
				if (root.LeftNode == null)
				{
					root.LeftNode = new Node(Value);
					root.LeftNode.Parent = root;
				}
				else
				{
					AddTo(Value, root.LeftNode);
				}
			}
			else if (root.RightNode == null)
			{
				root.RightNode = new Node(Value);
				root.RightNode.Parent = root;
			}
			else AddTo(Value, root.RightNode);
		}

		public Node Find(int value)
		{
			return Find(value, Root);
		}

		public void Delete(int value, bool right)
		{
			if (Root == null)
			{
				Console.WriteLine("Empty tree");
				return;
			}
			Node current;
			current = Find(value, Root);

			if (current != null)
			{
				if (current.LeftNode == null && current.RightNode == null)
				{
					if (current != Root)
						if (current.Parent.LeftNode == current)
							current.Parent.LeftNode = null;
						else current.Parent.RightNode = null;

					current = null;

				}
				else if (right)
				{
					if (current.RightNode == null) // if no right subtree when right deleting
					{
						if (current.Parent != null)
						{
							if (current.Parent.LeftNode == current)
								current.Parent.LeftNode = current.LeftNode;
							else
								current.Parent.RightNode = current.LeftNode;
						}

						current.LeftNode.Parent = current.Parent;

						current = null;

					}
					else
						RightDelete(current);
				}
				else
				{
					if (current.LeftNode == null) // if no left subtree when left deleting
					{
						if (current.Parent != null)
						{
							if (current.Parent.LeftNode == current)
								current.Parent.LeftNode = current.RightNode;

							else current.Parent.RightNode = current.RightNode;
						}
						current.RightNode.Parent = current.Parent;

						current = null;
					}
					else LeftDelete(current);
				}
				Console.WriteLine("Deleted");
			}
			else Console.WriteLine("Not found");
		}

		private void RightDelete(Node Root)
		{
			Node current = Root.RightNode;

			while (current.LeftNode != null)
				current = current.LeftNode;

			if (current.Parent != Root)
			{
				if (current.RightNode != null) // if replacement has right branch
				{
					current.Parent.LeftNode = current.RightNode;

					current.RightNode.Parent = current.Parent;
				}

				current.RightNode = Root.RightNode;
				Root.RightNode.Parent = current;
				current.Parent.LeftNode = null;
			}

			current.LeftNode = Root.LeftNode;
			if (Root.LeftNode != null)
				Root.LeftNode.Parent = current;

			if (Root.Parent != null) // re-linking orphans
			{
				if (Root.Parent.LeftNode == Root)
					Root.Parent.LeftNode = current;
				else Root.Parent.RightNode = current;
			}

			current.Parent = Root.Parent;

			if (Root == this.Root) // root case
			{
				this.Root = null;
				this.Root = current;
			}
			else
			{
				Root = null;
				Root = current;
			}
		}

		private void LeftDelete(Node Root)
		{
			Node current = Root.LeftNode;
			while (current.RightNode != null)
				current = current.RightNode;

			if (current.Parent != Root)
			{
				if (current.LeftNode != null) // if replacement has right branch
				{
					current.Parent.RightNode = current.RightNode;

					current.LeftNode.Parent = current.Parent;
				}

				current.LeftNode = Root.LeftNode;
				Root.LeftNode.Parent = current;
				current.Parent.RightNode = null;
			}

			current.RightNode = Root.RightNode;
			if (Root.RightNode != null)
				Root.RightNode.Parent = current;

			if (Root.Parent != null) // re-linking orphans
			{
				if (Root.Parent.LeftNode == Root)
					Root.Parent.LeftNode = current;
				else Root.Parent.RightNode = current;
			}

			current.Parent = Root.Parent;

			if (Root == this.Root) // root case
			{
				this.Root = null;
				this.Root = current;
			}
			else
			{
				Root = null;
				Root = current;
			}
		}

		private Node Find(int value, Node parent)
		{
			if (parent != null)
			{
				if (value == parent.Value) return parent;
				if (value < parent.Value)
					return Find(value, parent.LeftNode);
				else
					return Find(value, parent.RightNode);
			}

			return null;
		}


		public int GetDepth(int value)
		{
			if (Root == null)
			{
				Console.WriteLine("Empty tree");
				return -1;
			}
			else
			{
				Node current = Find(value, Root);
				if (current == null)
				{
					Console.WriteLine("Такого элемента нет");
					return -1;
				}
				else
				{
					int count = 0; // root depth
					if (current != Root)
						count = 1 + SubDepth(current.Parent);
					//Console.WriteLine("Depth: " + count);
					return count;
				}
			}
		}

		private int SubDepth(Node root)
		{
			int count = 0;
			if (root.Parent != null)
				count = 1 + SubDepth(root.Parent);
			return count;
		}

		public int GetHeight(int value)
		{
			if (Root == null)
			{
				Console.WriteLine("Empty tree");
				return -1;
			}
			else
			{
				Node current = Find(value, Root);
				if (current == null)
				{
					Console.WriteLine("No such element found");
					return -1;
				}
				else
				{
					int count = 0;
					count = Math.Max(SubHeight(current.LeftNode), SubHeight(current.RightNode));
					//Console.WriteLine("Height: " + count);
					return count;
				}
			}
		}

		private int SubHeight(Node root)
		{
			int count = 0;
			if (root != null)
			{
				count = 1 + Math.Max(SubHeight(root.LeftNode), SubHeight(root.RightNode));
			}
			return count;
		}

		public int GetLevel(int value)
		{
			if (Root == null)
			{
				Console.WriteLine("Empty tree");
				return -1;
			}
			else
			{
				Node current = Find(value, Root);
				if (current == null)
				{
					Console.WriteLine("No such element");
					return -1;
				}
				else
				{
					int count = 0;
					if (current != Root)
						count = SubHeight(Root) - SubDepth(current) - 1;
					return count;
					//Console.WriteLine("Level: " + count);
				}

			}
		}



		public void PrintTree()
		{
			if (Root != null)
				Root.Print("", NodePosition.center, true, false);
			else
				Console.WriteLine("Empty tree");
		}

		public void Print(int type)
		{
			if (type == 1)
				TraversePreOrder(Root);
			else if (type == 2)
				TraversePostOrder(Root);
			else TraverseInOrder(Root);
		}

		public void TraversePreOrder(Node parent)
		{
			if (parent != null)
			{
				Console.Write(parent.Value + " ");
				TraversePreOrder(parent.LeftNode);
				TraversePreOrder(parent.RightNode);
			}
		} // direct

		public void TraverseInOrder(Node parent)
		{
			if (parent != null)
			{
				TraverseInOrder(parent.LeftNode);
				Console.Write(parent.Value + " ");
				TraverseInOrder(parent.RightNode);
			}
		} // symmetric

		public void TraversePostOrder(Node parent)
		{
			if (parent != null)
			{
				TraversePostOrder(parent.LeftNode);
				TraversePostOrder(parent.RightNode);
				Console.Write(parent.Value + " ");
			}
		} // reverse


		/* 'Task' zone */

		private int counter;
		private List<Tuple<Node, int>> powerLevelsLeftMajor = new List<Tuple<Node, int>>();
		private List<Tuple<Node, int>> powerLevelsRightMajor = new List<Tuple<Node, int>>();
		private List<Node> taskNodes = new List<Node>();

		private void GetPowerLevelsLeft(Node root, bool isLeft)
		{
			//if (root != null)
			//{
				if (isLeft)
				{
					counter = 0;
					TraversePreOrderTask(root.LeftNode, root, true);
					powerLevelsLeftMajor.Add(new Tuple<Node, int>(root.LeftNode, counter));
					GetPowerLevelsLeft(root.LeftNode, true);
					TraversePreOrderTask(root.RightNode, root, true); // ?
					isLeft = false;
				}
				else
				{
					counter = 0;
					TraversePreOrderTask(root.LeftNode, root, false); // ?
					powerLevelsLeftMajor.Add(new Tuple<Node, int>(root.RightNode, counter)); // ?
					GetPowerLevelsLeft(root.RightNode, false);
					TraversePreOrderTask(root.RightNode, root, false); // ?
				}
			//}
		}

		public void Task()
		{
			//PrintTree();
			TraversePreOrder(Root); // 1
			MajorLeftSubtrees(Root, Root);
			MajorRightSubtrees(Root, Root);
			// getting nodes needed 
			foreach (Tuple<Node, int> left in powerLevelsLeftMajor)
			{
				foreach (Tuple<Node, int> right in powerLevelsRightMajor)
				{
					if (Math.Abs(left.Item2 - right.Item2) == 1 && (!taskNodes.Contains(left.Item1) && !taskNodes.Contains(right.Item1)))
					{
						taskNodes.Add(left.Item1);
						taskNodes.Add(right.Item1);
					}
				}
			}

			int acc = 0, avg = 0; // acc - result accumulator, avg - average root value, may or may not not exist
			foreach (Node node in taskNodes)
			{
				acc += node.Value;
			}
			int size = taskNodes.ToArray().Length;
			if(size==0)
			{
				Console.WriteLine("No valid node found");
				return;
			}
			avg = acc / size;
			Console.WriteLine("\nAverage value:" + avg);
			Node taskNode = Find(avg);
			if(taskNode == null)
			{
				Console.WriteLine("No node with value {0} found",avg);
				return;
			}
			Delete(avg, true);
			TraversePreOrder(Root); // 2
			//PrintTree();
		}

		private void MajorLeftSubtrees(Node parent,Node root)
		{
			if (parent != null)
			{
				TraversePreOrderTask(parent, parent, true);
				counter--;
				powerLevelsLeftMajor.Add(new Tuple<Node, int>(parent,counter));
				counter = 0;
				root = parent;
				MajorLeftSubtrees(parent.LeftNode,root);
			}
			if(root.RightNode!=null)
			{
				MajorLeftSubtrees(root.RightNode, root);
			}
		}

		private void MajorRightSubtrees(Node parent, Node root)
		{
			if (parent != null)
			{
				TraversePreOrderTask(parent, parent, false);
				counter--;
				powerLevelsRightMajor.Add(new Tuple<Node, int>(parent, counter));
				counter = 0;
				root = parent;
				MajorRightSubtrees(parent.LeftNode, root);
			}
			if (root.RightNode != null)
			{
				MajorRightSubtrees(root.RightNode, root);
			}
		}

		public void TraversePreOrderTask(Node parent, Node root, bool lefttSubtree) // leftsubtree - no going right on root level
		{
			if (lefttSubtree == true)
			{
				if (parent != null && parent != root.RightNode)
				{
					counter++;
					TraversePreOrderTask(parent.LeftNode, root, lefttSubtree);
					TraversePreOrderTask(parent.RightNode, root, lefttSubtree);
				}
			}
			else
			{
				if (parent != null && parent != root.LeftNode)
				{
					counter++;
					TraversePreOrderTask(parent.LeftNode, root, lefttSubtree);
					TraversePreOrderTask(parent.RightNode, root, lefttSubtree);
				}
			}
		}

		

	}
}