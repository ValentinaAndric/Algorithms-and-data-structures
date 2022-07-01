<Query Kind="Program" />

void Main()
{
	int v = 5;
	GFG graph = new GFG();
    List<LinkedList> adj = new List<LinkedList>();
	for (int i =0; i<v; i++)
	{
	  adj.Add(new LinkedList());
	}
	graph.insertToList(adj, 0,1);
	graph.insertToList(adj, 1,4);
	graph.insertToList(adj, 2,2);
	graph.insertToList(adj, 3,4);
	graph.insertToList(adj, 4,1);
	graph.insertToList(adj, 0,2);
	graph.insertToList(adj, 1,2);
	graph.insertToList(adj, 2,2);
	graph.insertToList(adj, 3,2);
	graph.insertToList(adj, 4,2);
	graph.insertToList(adj, 1,2);
	graph.insertToList(adj, 2,2);
	graph.insertToList(adj, 3,2);
	graph.insertToList(adj, 4,2);
	graph.insertToList(adj,4,4);
	
	
	Console.WriteLine("Matrix adjacency");
	int[,] matrix = graph.convertListToMatrix(adj,v);
	graph.printMatrix(matrix,v);
	Console.WriteLine("Adjacency list");
	List<LinkedList> lst = graph.convertMatrixToList(matrix);
	graph.printList (lst);
	
}

public class GFG
{
  public void insertToList (List<LinkedList> adj, int u, int v)
  {
    adj[u].addTail(v);
	return;
  }
  
  public int[,] convertListToMatrix (List<LinkedList> adj, int v)
  {
      int[,] matrix = new int[v,v];
	  for (int i =0; i< v; i++)
	  {
	     LinkedList.Node temp = adj[i].head;//Moramo dodeliti glavu pomocnoj promenljivoj za svaku od listi
		 while (temp!=null)
		 {
		   matrix[i, temp.value]=1;
		   temp = temp.next;
		 }
		 
	  
	  }
	  return matrix;
  
  }
  
  public List<LinkedList> convertMatrixToList (int[,] matrix)
  {
  
      int l = matrix.GetLength(0);
	  List<LinkedList> adj = new List<LinkedList> (l);
	  for (int i =0; i < l; i++)
	  {
	    adj.Add(new LinkedList());
	  }
	  
	  for (int i =0; i< matrix.GetLength(0); i++)
	  {
	     for (int j=0; j<matrix.GetLength(1); j++)
		 {
		   if (matrix[i,j]==1)
		   {
		      adj[i].addTail(j);
		   }
		 
		 }
	  }
     return adj;
  }
  
  public void printList (List<LinkedList> adj)
  {
    for (int i =0; i<adj.Count; i++)
	{
	  Console.Write(i);
	  LinkedList.Node temp = adj[i].head;
	  if(temp!= null)
	  {
	    Console.Write("-->"+ temp.value + "  ");
		temp= temp.next;
	  }
	  Console.WriteLine();
	  
	}
  
  }
  
  public void printMatrix (int[,] matrix, int v)
  {
    for (int i=0; i<v; i++)
	{
	  for (int j=0; j<v; j++)
	  {
	     Console.Write(matrix[i,j]+ " ");
	  }
	Console.WriteLine();
	}
   Console.WriteLine();
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