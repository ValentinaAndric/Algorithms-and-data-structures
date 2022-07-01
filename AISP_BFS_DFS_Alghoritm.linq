<Query Kind="Program" />

void Main()
{
	
}

public class Graphs
{
private List<LinkedList> adjecency;
private int [,] adjecencyMatirx;
private int time;
 
  public Graphs()
  {
    adjecency = new List<LinkedList>();
  }
  public void addEdge (int u, int v)
  {  
    adjecency[u].addTail(v);//Na odgovarajucem cvoru (LinkedList) dodajem u nju rep odnosno povezujem sa nekim drugim cvorom
  }
  public void addVertax ()
  {
    adjecency.Add(new LinkedList());//Dodajem cvor tako sto u listu dodajem novu LinkedListu
  }
  
  public void BFS (int startVertax)
  {
    LinkedList.Node temp = adjecency[startVertax].head;//Uzimamo od nase startne liste prvi cvor SVE ELEMENTE TE STARTNE LISTE POSTAVLJAMO NA BELO
	while (temp!= null)
	{
	  temp.weight =0;
	  temp.color = "WIHTE";
	  temp= temp.next;
	  
	}
	
	LinkedList.Node startNode = adjecency[startVertax].head;
	startNode.color = "GRAY";
	startNode.weight=0;
	Queue queue = new Queue ();
	queue.Enqueue(startNode.value);
	while (queue.Size() >0)
	{
	  int temp2 = (int)queue.Dequeue();//Skidamo sa reda onu vrednost koji treba da ispisemo
	  Console.WriteLine (temp2 + " ");
	  LinkedList.Node temp3 = adjecency[temp2].head;//Ispisuje se ona lista iz Liste koja je prva posivela i dodata je na red od nje se krece i ispisuju se cvorovi iskljucujuci prvi koji je vec postajao u okviru neke druge
	                                                //Sada cemo samo od nje krenuti i njene cvorove ispisivati
	  
	  while (temp3!= null)
	  { 
	      if (temp3.color == "WHITE")
		  {
		     LinkedList.Node currentParent = adjecency[temp3.value].head;//Ako je njegova vrednost 3 onda je to treca LinkedLista iz List-e
			 currentParent.color = "GRAY";
			 queue.Enqueue(currentParent.value);//Sivi su oni koji su bili beli pa su se dodali u red pa su postali sivi
		  
		  }
	  
	  }
	  temp3.color = "BLACK";//Postaavimo na crno taj sa kojim smo zavrsili ili smo ga dodali u red ili je vec dodat pa smo ga preskocili
	  temp3 = temp3.next;
	
	}
  }
  
  public int [,] convertListToMatrix (List<LinkedList> adj)
  {
     adjecencyMatirx = new int[adj.Count, adj.Count];
     for (int i=0; i< adj.Count; i++)
	 {
	   LinkedList.Node temp = adj[i].head;
	   if (temp!= null)
	   {
	     adjecencyMatirx[i, temp.value]=1;
		 temp = temp.next;
	   }
	 
	 }
  return adjecencyMatirx;
  }
  
  public List<LinkedList> convertMatrixToList ()
  { 
      int l = adjecencyMatirx.GetLength(0);
	  adjecency = new List<LinkedList>(l);
	  for (int i=0; i<l; i++)
	  {
	    addVertax();
	  
	  }
	  for(int i =0; i< adjecencyMatirx.GetLength(0); i++)
	  {
	    for (int j=0; j<adjecencyMatirx.GetLength(1); j++)
		{
		   if (adjecencyMatirx[i,j] == 1)
		   {
		   
		     addEdge(i,j);
		   }
		
		}
	  
	  }
      return adjecency;
   
  }
  
  public void DFS ()
  {
    for (int i=0; i< adjecency.Count; i++)
	{   
	    LinkedList.Node temp = adjecency[i].head;
		if (temp!= null)
		{
		  temp.color = "WHITE";
		  temp.weight =0;
		  temp = temp.next;
		
		}
		time =0;
		for (i=0; i< adjecency.Count; i++)
		{
		   LinkedList.Node curr = adjecency[i].head;
		   while (curr!= null)
		   {
		  if (curr.color == "WHITE" && adjecency[curr.value].head.color == "WHITE")
		  {
		    DFSVisit (curr, i);
		  }
		  curr = curr.next;
		  }
		}	
	}
  }
    public void DFSVisit (LinkedList.Node temp, int index)
	{
	  time ++;
	  temp.color = "GRAY";
	  temp.weight = time;
	  Console.WriteLine(temp.value);
	  
	  LinkedList.Node temp2 = adjecency[index].head;
	  while (temp2!= null)
	  {
	     if (temp2.color == "WHITE")
		 {
		    LinkedList.Node parent = adjecency[temp2.value].head;
			if (parent.color == "WHITE")
			{
			  parent.color = "GREY"
			  DFSVisit (temp2, temp2.value);
			}
		 
		 }
		 temp2 = temp2.next;
	  
	  
	  }
	  temp.color = "BLACK";
	  time++;
	  temp.forest = time;
	  
	
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
