<Query Kind="Program" />

void Main()
{
	CircularLinkedList lst = new CircularLinkedList();
	lst.addHead (5);
	lst.addTail (2);
	lst.addHead(8);
	lst.addHead(7);
	lst.print();
}

public class CircularLinkedList 
{
   private class Node
   {
       internal int value;
	   internal Node next;
      
     public Node (int v, Node n)
	 {
	     value= v;
		 next = n;
	 
	 }  
   }
   private Node tail;
   private int count=0;
   
   public void addHead (int value)
   {
     Node temp = new Node (value, null);
	 if (count == 0)
	 {
	    tail=temp;
		temp.next = temp;
	 }
	 else
	 {
	   temp.next = tail.next;
	   tail.next = temp;
	 }
   count ++;
   }
   
   public void addTail(int value)
   {
   	   Node temp = new Node(value, null);
	   
	   if(count == 0)
	   {
	      tail = temp;
		  temp.next = temp;
	   }
	   else
	   {
	      temp.next = tail.next;
		  tail.next = temp;
		  tail=temp;
	   }
	   count++;
   }
   
   public void print()
   {
      if (count ==0)
	  {
	   Console.WriteLine("List is empty");
	  }
	  else
	  {
	     Node temp = tail;
		 for (int i =0; i< count; i++)
		 {
		   Console.Write( temp.value + " ");
		   temp = temp.next;
		 }
	  
	  } 
   }
   public void deleteList ()
   {
   tail = null;
   count = 0;   
   }
   
  private Node findNode (int value)
  {   
     Node temp = tail;
	 for (int i=0; i<count; i++)
	 {
	   if (temp.value == value)
	   {
	    return temp;
	   }
	   temp = temp.next;
	 }
    return null;
  }
  
  private bool SearchList (int value)
  {
    Node temp = findNode(value)
	if (temp!=null)
	{
	 return true;
	}
	return false;
  }
  
  public bool delete(int value)
  {
    if (count == 0)
	{
	  return false;
	}
	
	Node prev = tail;
	Node curr = tail.next;
	Node head = tail.next;
	
	if (curr.value == value)
	{  
	    if (curr == curr.next)
		{
		 tail = null
		 count--;
		}
		else 
		{
		  tail.next = tail.next.next;
		  count--;
		}
	 return true;
	}
	prev = curr;
	curr = curr.next;
	while (curr != head)
	{
	   if (curr.value==value)
	   {
	      if (curr == tail)
		  {
		   prev = tail;
		  }
		  prev.next = curr.next
		  return true;
	   }
	   prev = curr;
	   curr = curr.next;
	}
	return false;
  
  }
}