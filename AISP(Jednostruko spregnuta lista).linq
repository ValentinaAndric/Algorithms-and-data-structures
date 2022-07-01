<Query Kind="Program" />

void Main()
{
	LinkedList list = new LinkedList();
	list.addHead(2);
	list.addTail(3);
	list.addTail(4);
	list.delete(3);
	list.searchList(2);
	list.removeHead();
	Console.WriteLine (" " + list.searchList(2));
	list.print();
}

public class LinkedList
{

  private class Node
  {
      internal int value;
	  internal Node next;
	  
	  public Node (int v, Node n)
	  {
	      value = v;
		  next = n;  
	  }
  
  }
  private Node head;
  private int count=0;
  
  public void addHead (int value)
  {
     head = new Node(value,head);
	 count++;
  
  }
  
  public void addTail (int value)
  {
     Node newNode = new Node (value,null);
	 Node curr = head;
	 if (head==null)
	 {
	    head = newNode;
		count ++;
		return;
	 } 
	 
	 while (curr.next != null)
	  {
	     curr= curr.next;	 
	  }
	  curr.next = newNode;
	  count++;
  }
  
  public void deleteList ()
  {
    head = null;
	count =0;
  
  }
  
  public void print ()
  {  
	    Node curr = head;
		if (head == null)
		{
		  Console.WriteLine("List is empty!");
		}
		while (curr != null)
		{
		   Console.Write(curr.value + " ");
		   curr = curr.next;
		} 
  
  }
  
  public bool removeHead()
  {
    if (count ==0)
	{
	  return false;
	}
	else
	{
	   head = head.next;
	   count--;
	   return true;
	}
  }
  
  public bool delete(int value)
  {
     Node curr = head;
	 if (head == null)
	 {
	   return false;
	 }
	 
	 if (curr.value ==  value)
	 {
	   head = head.next;
	   count--;
	   return true;
	 
	 }
	 while (curr.next !=null)
	 {
	    if (curr.next.value == value)
		{
		   curr.next = curr.next.next;
		   count--;
		   return true;
		   
		}
		curr = curr.next;
	 
	 }
	 return false;
  }
  
  private Node findNode (int value)
  { 
    Node curr = head;
	
	while (curr != null)
	{
	  if (curr.value == value)
	  {
	    return curr;
	  }
	  curr = curr.next;
	  
	}	
	return null;
  }
  
  public bool searchList (int value)
  {
     Node curr = findNode(value);
	 if(curr != null)
	 {
	   return true;
	 }
	 return false;
  }
  

}