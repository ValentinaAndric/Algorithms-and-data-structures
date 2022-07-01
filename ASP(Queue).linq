<Query Kind="Program" />

void Main()
{
 Queue queue= new Queue ();
 queue.enqueue (1);
 queue.enqueue (2);
 queue.enqueue (3);
 Console.WriteLine (queue.peek());
 queue.print();
 
 
	
}

public class Queue
{
private Node tail=null;
 private int count=0;

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
 
 public int size ()
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
 public void enqueue (int value)
 {
     Node temp = new Node (value,null);
    if (tail==null)
	{
	   tail = temp;
	   tail.next = tail;
	}
	else
	{
	  temp.next = tail.next;
	  tail.next=temp;
	  tail = temp;
	  
	}
	count++;
 }
 
 public int? dequeue ()
 {
    if (count==0)
	{
	  return null; 
	}
	int value = 0;
	if (tail == tail.next)
	{
	  value = tail.value;
	  tail = null;
	}
	
	else
	{
	   value = tail.next.value;
	   tail.next = tail.next.next; //Kod reda prvi element u redu pokazuje na poslednji element u listi tj u njegovom next-u se nalazi poslednji el
	}
    count --;
	return value;
 
 }
 
 public int? peek ()
 {
     
    if(count == 0)
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
 
public void print ()
{
  Node temp = tail;
  for (int i=0; i<count; i++)
  {
     Console.Write(temp.value + " ");
	 temp = temp.next;
  }
  }
}
