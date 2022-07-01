<Query Kind="Program" />

void Main()
{
	BinarySearchTree bst = new BinarySearchTree();
	bst.Insert(10);
	bst.Insert(13);
	bst.Insert(12);
	bst.Insert(16);
	bst.Insert(14);
	bst.Insert(11);
	bst.Insert(15);

	bst.Insert(5);
	bst.Insert(8);
	bst.Insert(7);
	bst.Insert(6);
	bst.Insert(3);
	bst.Insert(2);
	bst.Insert(4);
	bst.Insert(1);

	Console.WriteLine("Started tree: ");
	bst.PrintInOrder();
	
	Console.WriteLine();
	Console.WriteLine("Mirrored tree: ");
	BinarySearchTree mirrorTree = bst.CopyMirrorTree();
	mirrorTree.PrintInOrder();
}

public class BinarySearchTree
{
	private Node root;
	
	private class Node
	{
		internal int value;
		internal Node lChild;
		internal Node rChild;
		internal Node parent;
		
		public Node(int value, Node left, Node right, Node parent)
		{
			this.value = value;
			lChild = left;
			rChild = right;
			this.parent = parent;
		}
		
		public Node(int value)
		{
			this.value = value;
			lChild = null;
			rChild = null;
			parent = null;
		}
	}
	
	public BinarySearchTree()
	{
		root = null;
	}
	
	public void Insert(int value)
	{
		root = InsertNode(root, value, null);
	}
	
	private Node InsertNode(Node node, int value, Node parent)
	{
		if (node == null)
		{
			node = new Node(value, null, null, parent);
		}
		else
		{
			if (node.value > value)
			{
				node.lChild = InsertNode(node.lChild, value, node);
			}
			else
			{
				node.rChild = InsertNode(node.rChild, value, node);
			}
		}
		return node;
	}
	
	public void Delete(int value)
	{
		root = DeleteNode(root, value);
	}
	
	private Node DeleteNode(Node currentNode, int value)
	{
		Node temp = null;
		
		if (currentNode != null)
		{
			if (currentNode.value == value)
			{
				if (currentNode.lChild == null && currentNode.rChild == null)
				{
					return null;
				}
				else
				{
					if (currentNode.lChild == null)
					{
						temp = currentNode.rChild;
						temp.parent = currentNode.parent;
						return temp;
					}
					
					if (currentNode.rChild == null)
					{
						temp = currentNode.lChild;
						temp.parent = currentNode.parent;
						return temp;
					}
					
					Node minNode = FindMinNode(currentNode.rChild);
					int minValue = minNode.value;
					currentNode.value = minValue;
					currentNode.rChild = DeleteNode(currentNode.rChild, minValue);
				}
			}
			else
			{
				if (currentNode.value > value)
				{
					currentNode.lChild = DeleteNode(currentNode.lChild, value);
				}
				else
				{
					currentNode.rChild = DeleteNode(currentNode.rChild, value);
				}
			}
		}

		return currentNode;
	}
	
	public bool Find(int value)
	{
		Node curr = root;
		
		while (curr != null)
		{
			if (curr.value == value)
			{
				return true;
			}
			else if (curr.value > value)
			{
				curr = curr.lChild;
			}
			else
			{
				curr = curr.rChild;
			}
		}
		return false;
	}
	
	public int? FindMin()
	{
		Node min = FindMinNode(root);
		
		if (min == null)
		{
			return null;
		}
		
		return min.value;
	}
	
	public int? FindMax()
	{
		Node max = FindMaxNode(root);
		
		if (max == null)
		{
			return null;
		}
		
		return max.value;
	}
	
	private Node FindMinNode(Node curr)
	{
		if (curr == null)
		{
			return null;
		}
		
		while (curr.lChild != null)
		{
			curr = curr.lChild;
		}
		return curr;
	}
	
	private Node FindMaxNode(Node curr)
	{		
		if (curr == null)
		{
			return null;
		}
		
		while (curr.rChild != null)
		{
			curr = curr.rChild;
		}
		return curr;
	}
	
	public void PrintInOrder()
	{
		PrintInOrder(root);
	}
	
	private void PrintInOrder(Node current)
	{
		if (current != null)
		{
			PrintInOrder(current.lChild);
			Console.Write(" " + current.value);
			PrintInOrder(current.rChild);
		}
	}
	
	public BinarySearchTree CopyMirrorTree()
	{
		BinarySearchTree mirrorTree = new BinarySearchTree();
		mirrorTree.root = CopyMirrorTree(root);
		return mirrorTree;
	}
	
	private Node CopyMirrorTree(Node current)
	{
		Node temp;
		if (current != null)
		{
			temp = new Node(current.value);
			temp.rChild = CopyMirrorTree(current.lChild);
			temp.lChild = CopyMirrorTree(current.rChild);
			return temp;
		}
		else
		{
			return null;
		}
	}
}

// You can define other methods, fields, classes and namespaces here
