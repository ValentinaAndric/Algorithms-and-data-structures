<Query Kind="Program" />

void Main()
{
	//Primer 1
	Graphs graph = new Graphs();
	
	graph.addVertex();
	graph.addVertex();
	graph.addVertex();
	graph.addVertex();
	graph.addVertex();
	graph.addVertex();
	
	graph.addEdge(0, 0);
	graph.addEdge(0, 1);
	graph.addEdge(0, 3);
	graph.addEdge(0, 2);
	
	graph.addEdge(1, 1);
	graph.addEdge(1, 0);
	graph.addEdge(1, 3);
	graph.addEdge(1, 4);
	
	graph.addEdge(2, 2);
	graph.addEdge(2, 0);
	graph.addEdge(2, 3);
	
	graph.addEdge(3, 3);
	graph.addEdge(3, 1);
	graph.addEdge(3, 0);
	graph.addEdge(3, 2);
	graph.addEdge(3, 4);
	
	graph.addEdge(4, 4);
	graph.addEdge(4, 1);
	graph.addEdge(4, 3);
	graph.addEdge(4, 5);
	
	graph.addEdge(5, 5);
	graph.addEdge(5, 4);
	
	Console.WriteLine("--- BFS ---");
	int i = graph.BFS(0, 5);
	Console.WriteLine(i);
}

public class Graphs
{
	public Graphs()
	{
		adjacencyList = new List<LinkedList>();
	}

	private List<LinkedList> adjacencyList;
	private int[,] adjacencyMatrix;
	private int time;

	public void addEdge(int u, int v)
	{   
		adjacencyList[u].addTail(v);
		return;
	}
	
	public void addVertex()
	{
		adjacencyList.Add(new LinkedList());
	}
	
	public int[,] convertListToMatrix()
	{
		adjacencyMatrix = new int[adjacencyList.Count, adjacencyList.Count];
		
		for (int i = 0; i < adjacencyList.Count; i++)
		{
			LinkedList.Node temp = adjacencyList[i].head;
			while (temp != null)
			{
				adjacencyMatrix[i, temp.value] = 1;
				temp = temp.next;
			}
		}
		return adjacencyMatrix;
	}
	
	public List<LinkedList> convertMatrixToList()
	{
		int l = adjacencyMatrix.GetLength(0);
		adjacencyList = new List<LinkedList>(l);
        int i, j;
        
        for (i = 0; i < l; i++) 
        {
            addVertex();
        }
          
        for (i = 0; i < adjacencyMatrix.GetLength(0); i++) 
        {
            for (j = 0; j < adjacencyMatrix.GetLength(1); j++)
            {
                if (adjacencyMatrix[i,j] == 1) 
                {
					addEdge(i, j);
                }
            }
        }
  
        return adjacencyList;
	}
	
	public int BFS(int startVertex, int endVertex)
	{
		for (int i = 0; i < adjacencyList.Count; i++)
		{
			LinkedList.Node temp = adjacencyList[i].head;
			while (temp != null)
			{
				temp.weight = 0;
				temp.color = "WHITE";
				temp = temp.next;
			}
		}

		int[] level = new int[adjacencyList.Count];
		LinkedList.Node startNode = adjacencyList[startVertex].head;
		startNode.color = "GRAY";
		startNode.weight = 0;

		Queue queue = new Queue();
		queue.Enqueue(startNode.value);
		level[startVertex] = 0;
		while (queue.Size() != 0)
		{
			int tempNode = (int)queue.Dequeue();
			int depth = level[tempNode];

			LinkedList.Node temp = adjacencyList[tempNode].head;
			while (temp != null)
			{
				if (temp.value == endVertex)
				{
					// return temp.weight;
					return depth;
				}
				if (temp.color == "WHITE")
				{
					LinkedList.Node currentParent = adjacencyList[temp.value].head;
					if (currentParent.color == "WHITE")
                    {
						currentParent.color = "GRAY";
						level[currentParent.value] = depth + 1;
						queue.Enqueue(temp.value);
					}

					temp.color = "GRAY";
					temp.weight++;
				}
				temp.color = "BLACK";
				temp = temp.next;
			}
		}
		return -1;
	}
	    
    public void printList() 
    {
        for (int v = 0; v < adjacencyList.Count; v++) 
        {
            Console.Write(v);
			LinkedList.Node temp = adjacencyList[v].head;
            while (temp != null)
			{
				Console.Write(" --> " + temp.value);
				temp = temp.next;
			}
            Console.WriteLine();
        }
    }
	
	public void printMatrix()
	{
	    for(int i = 0; i < adjacencyMatrix.GetLength(0); i++)
	    {
	        for(int j = 0; j < adjacencyMatrix.GetLength(1); j++)
	        {
	            Console.Write(adjacencyMatrix[i, j] + " ");
	        }
	        Console.WriteLine();
	    }
	    Console.WriteLine();
	}
}

public class Queue
{
	private Node tail = null;
	private int count = 0;

	private class Node
	{
		internal int value;
		internal Node next;

		public Node(int v, Node n)
		{
			value = v;
			next = n;
		}
	}

	public int Size()
	{
		return count;
	}

	public bool isEmpty
	{
		get
		{
			return count == 0;
		}
	}

	public void Enqueue(int value)
	{
		Node temp = new Node(value, null);
		if (tail == null)
		{
			tail = temp;
			tail.next = tail;
		}
		else
		{
			temp.next = tail.next;
			tail.next = temp;
			tail = temp;
		}
		count++;
	}

	public int? Dequeue()
	{
		if (count == 0)
		{
			return null;
		}

		int value;
		if (tail == tail.next)
		{
			value = tail.value;
			tail = null;
		}
		else
		{
			value = tail.next.value;
			tail.next = tail.next.next;
		}
		count--;
		return value;
	}

	public int? Peek()
	{
		if (count == 0)
		{
			return null;
		}

		int value;
		if (tail == tail.next)
		{
			value = tail.value;
		}
		else
		{
			value = tail.next.value;
		}
		return value;
	}
}

public class LinkedList
{
	public class Node
	{
		internal int value;
		internal int weight;
		internal int forest;
		internal Node next;
		internal String color;
		
		public Node(int v, Node n)
		{
			value = v;
			next = n;
		}
		
		public Node(int v, int w, Node n, String c)
		{
			value = v;
			weight = w;
			next = n;
			color = c;
		}
	}
	
	public Node head;
	public int count = 0;
	
	public void addHead(int value)
	{
		head = new Node(value, head);
		count++;
	}
	
	public void addTail(int value)
	{
		Node newNode = new Node(value, null);
		Node curr = head;
		
		if (head == null)
		{
			head = newNode;
			count++;
			return;
		}
		
		while (curr.next != null)
		{
			curr = curr.next;
		}
		
		curr.next = newNode;
		count++;
	}
		
	public void print()
	{		
		Node temp = head;
		while (temp != null)
		{			
			Console.Write(temp.value + "  ");
			temp = temp.next;
		}
	}		
	
	public bool searchList(int value)
	{
		Node temp = findNode(value);
		if (temp != null)
		{
			return true;
		}
		return false;
	}
	
	public bool removeHead()
	{
		if (count == 0)
		{
			return false;
		}
		head = head.next;
		count--;
		return true;
	}
	
	public bool delete(int value)
	{
		Node temp = head;
		if (count == 0)
		{
			return false;
		}
		
		if (temp.value == value)
		{
			head = head.next;
			count--;
			return true;
		}
		
		while (temp.next != null)
		{
			if (temp.next.value == value)
			{
				temp.next = temp.next.next;
				count--;
				return true;
			}
			temp = temp.next;
		}
		return false;
	}
	
	public void deleteList()
	{
		head = null;
		count = 0;
	}

	private Node findNode(int value)
	{
		Node temp = head;
		while (temp != null)
		{
			if (temp.value == value)
			{
				return temp;
			}
			temp = temp.next;
		}
		return null;
	}
}
