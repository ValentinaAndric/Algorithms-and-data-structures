<Query Kind="Program" />

void Main()
{
	Stack stack = new Stack();
	stack.push(5);
	stack.push(4);
	stack.push(6);
	StackQueueExercise.sortStack(stack);
	stack.print();
	
}

public class StackQueueExercise 
{

 public static void sortedInsert (Stack stack, int element)
  {
    int? temp;
	if(stack.size() == 0 || element<stack.peek())
	{
	  stack.push (element);
	}
	else
	{
	   temp = stack.pop();
	   sortedInsert(stack,element);
	   stack.push((int)temp);
	   
	}
  }
  
  public static void sortStack (Stack stack)
  {
    int? value = stack.pop();
	
	if(value != null)
	{
	 sortStack(stack);
	 StackQueueExercise.sortedInsert(stack, (int)value);
	}
  }
}

public class Stack
{  
   private Node head;
   private int count;
  public class Node
  {  
     internal int value;
	 internal Node next;
    public Node (int v, Node n)
	{
	    value= v;
		next=n;
	}
  }
  
  
  public bool isEmpty 
  {
      get 
	  {
	    return count == 0;
	  }
  }
  
  public int size ()
  {
     return count;
  }
  
  public int? peek ()
  {
     if (isEmpty)
	 {
	  return null;
	 }
	 
	 return head.value;
  }

public void push (int value)
{
  head = new Node (value, head);
  count ++;
}

public int? pop()
{
   if (isEmpty)
   {
     return null;
   }
   int value = head.value;
   head = head.next;
   count--;
   return value;
}

public void print ()
{
  Node temp = head;
  while(temp != null)
  {
    Console.Write(temp.value + " ");
	temp = temp.next;
  }
}
}