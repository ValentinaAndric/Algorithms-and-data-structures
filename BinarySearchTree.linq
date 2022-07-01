<Query Kind="Program" />

void Main()
{
	BinarySearchTree Bst = new BinarySearchTree ();
	Bst.Insert (1);
	Bst.Insert(10);
	Bst.Insert (2);
	Bst.printInOrder();
	Console.WriteLine();
	Bst.Delete(2);
	Bst.printInOrder();
	Console.WriteLine();
	Console.WriteLine (Bst.find(10));
	
}

public class BinarySearchTree 
{

public class Node
{
  internal Node lChild;
  internal Node rChild;
  internal Node parent;
  internal int value;
  
  public Node (Node lChild, Node rChild, Node parent, int value)
  {
     this.lChild = lChild;
	 this.rChild = rChild;
	 this.parent = parent;
	 this.value = value;
	 
  }
  
  public Node (int value)
  {
     lChild = null;
	 rChild = null;
	 parent = null;
	 this.value = value;
  }


}
 private Node root;
 
 public void Insert (int value)
 {
   root = InsertNode (root,null,value);
 }
 
 private Node InsertNode (Node node, Node parent, int value)
 {
    if (node == null)
	{
	   node = new Node (null, null, parent, value);
	}
	else
	{
	  if (node.value > value)
	  {
	  node.lChild = InsertNode (node.lChild, node, value);
	  }
	else
	{
	  node.rChild = InsertNode (node.rChild, node, value);
	}
	
  }
	
	return node;
 }
 
 public void printInOrder ()
 {
   printInOrder (root);
 }
 private void printInOrder (Node curr)
 {  
     if (curr != null)
	 {
     printInOrder (curr.lChild);
	 Console.Write(curr.value + "  ");
	 printInOrder (curr.rChild);
     }
 }
 
 public void Delete (int value)
 {
    root = DeleteNode (root, value);
 
 }
 
 private Node DeleteNode (Node current, int value)
 {  
     Node temp = null;
   if (current != null)
   {
      if (current.value == value)
	  {
	    if (current.lChild == null && current.rChild == null)
		{
		  return null;
		}
		else
		{
		if (current.lChild == null)
		{
		  temp = current.rChild;
		  temp.parent = current.parent;
		  return temp;
		}
		if (current.rChild == null)
		{
		   temp = current.lChild;
		   temp.parent = current.parent;
		   return temp;		
		}
		
		
		Node minNode = findMin (current.rChild);
		int minValue = minNode.value;
		current.value = minValue;
		current.rChild = DeleteNode (current.rChild,minValue);
	  }
	  } 
   
   else
   {
     if (current.value > value)
	 {
	   current.lChild = DeleteNode (current.lChild, value);
	 }
	 else
	 {
	   current.rChild = DeleteNode (current.rChild,value);
	 }
   }
   }
   return current;
 }
 
 public Node findMin (Node curr)
 {
    Node temp = findMinNode (curr);
	if (temp == null)
	{
	  return null;
	}
	return temp;
 }
 private Node findMinNode (Node curr)
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
 
 private Node findMaxNode (Node curr)
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
 public int?  findMax (Node curr)
 { 
    Node maxNode = findMaxNode (curr);
	if (maxNode == null)
	{
	  return null;
	}
	return maxNode.value;
  
 }
 public bool find (int value)
 {
    Node temp = root;
	
	while (temp != null)
	{
	   if (temp.value == value)
	   {
	     return true;
	   }
	   else if (temp.value > value)
	   {
	      temp = temp.lChild;
	   }
	   else 
	   {
	      temp= temp.rChild;
	   }
	
	}
	return false;
 
 }
 
}