<Query Kind="Program" />

void Main()
{
	int V = 5;
 
    List<LinkedList> adjList = new List<LinkedList>();
    for(int i = 0; i < V; i++)
        adjList.Add(new LinkedList());
         
    // Inserting edges
	GFG graph = new GFG();
    graph.insertToList(adjList, 0, 1);
    graph.insertToList(adjList, 0, 4);
    graph.insertToList(adjList, 1, 0);
    graph.insertToList(adjList, 1, 2);
    graph.insertToList(adjList, 1, 3);
    graph.insertToList(adjList, 1, 4);
    graph.insertToList(adjList, 2, 1);
    graph.insertToList(adjList, 2, 3);
    graph.insertToList(adjList, 3, 1);
    graph.insertToList(adjList, 3, 2);
    graph.insertToList(adjList, 3, 4);
    graph.insertToList(adjList, 4, 0);
    graph.insertToList(adjList, 4, 1);
    graph.insertToList(adjList, 4, 3);
 
    // Display adjacency list
    Console.Write("Adjacency List: \n");
    graph.printList(adjList);
 
	Console.WriteLine("Transposed adjacency list: ");
	graph.transposeGraph(adjList);
}

public class GFG
{
	public void insertToList(List<LinkedList> adj, int u, int v)
	{
		adj[u].addTail(v);
		return;
	}
	
	public int[,] convertListToMatrix(List<LinkedList> adj, int v)
	{
		int[,] matrix = new int[v, v];
		
		for (int i = 0; i < v; i++)
		{
			LinkedList.Node temp = adj[i].head;
			while (temp != null)
			{
				matrix[i, temp.value] = 1;
				temp = temp.next;
			}
		}
		return matrix;
	}
	
	public List<LinkedList> convertMatrixToList(int[,] matrix)
	{
		int l = matrix.GetLength(0);
		List<LinkedList> adjLinkedList = new List<LinkedList>(l);
        int i, j;
        
        for (i = 0; i < l; i++) 
        {
            adjLinkedList.Add(new LinkedList());
        }
  
          
        for (i = 0; i < matrix.GetLength(0); i++) 
        {
            for (j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i,j] == 1) 
                {
                    adjLinkedList[i].addTail(j);
                }
            }
        }
  
        return adjLinkedList;
	}
	    
    public void printList(List<LinkedList> adjListArray) 
    {
        for (int v = 0; v < adjListArray.Count; v++) 
        {
            Console.Write(v);
			LinkedList.Node temp = adjListArray[v].head;
            while (temp != null)
			{
				Console.Write(" --> " + temp.value);
				temp = temp.next;
			}
            Console.WriteLine();
        }
    }
	
	public void printMatrix(int[,] adj, int v)
	{
	    for(int i = 0; i < v; i++)
	    {
	        for(int j = 0; j < v; j++)
	        {
	            Console.Write(adj[i, j] + " ");
	        }
	        Console.WriteLine();
	    }
	    Console.WriteLine();
	}
	
	public void transposeGraph(List<LinkedList> adjacencyList)
	{
		int[,] adjacencyMatrix = convertListToMatrix(adjacencyList, adjacencyList.Count);
		adjacencyMatrix = transposeMatrix(adjacencyMatrix);
		adjacencyList = convertMatrixToList(adjacencyMatrix);
		printList(adjacencyList);
	}

	private static int[,] transposeMatrix(int[,] matrix)
	{
		int[,] transposedMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
		
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				transposedMatrix[j, i] = matrix[i, j];
			}
		}
		return transposedMatrix;
	}
}

public class LinkedList
{
	
	public class Node
	{
		internal int value;
		internal Node next;
		
		public Node(int v, Node n)
		{
			value = v;
			next = n;
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
