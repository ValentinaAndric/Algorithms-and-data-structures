<Query Kind="Program" />

void Main()
{
	
}

public class
{
  public class Node 
  {
       internal Node next;
	   internal Node prev;
	   internal int value;
      
      public Node (int v, Node nxt, Node prv)
	  {
	      value = v;
		  next = nxt;
		  prev = prv;
	  }
	  public Node (int v)
	  {
	    value = v;
		next = null;
		prev = null;
	  }
  }
  private Node head;
  private Node tail;
  private int count=0;
  
  public void addHeaad (int value)
  {
      Node newNode = new Node (value, null,null);
	  
     if (count ==0)
	 {
	   head = tail = newNode;
	 }
	 else
	 {
	    head.prev = newNode;
		newNode.next = head;
		head = newNode;
	 }
	 count++;
  }
  
  public void removeHead ()
  {
    if (count ==0)
	{
	  return;
	}
   head = head.next;
   if(head == null)
   {
      tail = null;
   }
   else
   {
      head.prev = null;
   }
  count--;
  }
  
  public void print ()
  {
    Node temp = head;
	while (temp != null)
	{
	 Console.WriteLine (temp.value + " ");
	}
	temp = temp.next;
  }
  
  public void deleteList ()
  {
    head = null;
	count = 0;
  }
  
  private Node findNode (int value)
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
  
  public bool searchNode (int value)
  {
    Node temp = findNode(value);
	if (temp != null)
	{
	  return true;
	}
	return false;
  }
  
  public bool delete (int value)
  {
    Node temp = findNode(value);
	if (temp == null)//Ne postoji taj element
	{
	  return false;
	}
	if (temp.value == head.value)//taj element je u listi prvi
	{
		head = head.next;//taj element je sledeci 
		if (head != null)//On pokazuje na nesto 
		{
		  head.prev = null;
		}
		else
		{
		  tail = null; //posto je glava pokazivala na prethodni head dereferenciraj je, to samo radimo u ovom slucaju kad imamo jedan element, jer je rep i glava ista, inace je rep na kraju uvek
		}
		return true;
	}
	if (temp.next == null) //poslednji element u listi
	{
	   temp.next.prev = null;
	}
    else
	{
	   temp.prev.next = temp.next;
	   temp.next.prev = temp.prev;
	}
     count --;
	 return true;
  }
}