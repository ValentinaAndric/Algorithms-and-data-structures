<Query Kind="Program" />

void Main()
{
	
}
public class Node 
{   
    internal int value;
	internal Node left;
	internal Node right;
   public Node (int value,Node left, Node right)
   {
      this.value = value;
	  this.left = left;
	  this.right = right;
	  
   }
}

public class Heap
{
  private Node[] array;
  private int count;
  private int Capacity = 32;
  private bool isMinHeap;
  
  public Heap (bool isMin = true)
  {
    count=0;
	isMinHeap= isMin;
	array = new Node [Capacity];
  }
  
   public Heap(Node [] array, bool isMin = true)
  {
     count = array.Length;
	 isMinHeap = isMin;
	 this.array = new Node[array.Length];
	 Array.Copy(array,0, this.array,0,array.Length);
     buildHeap(); 
  }
  
  public void buildHeap ()
  {
    for (int i =0; i< count/2; i++)
	{
	  heapify(array[i]);
	}
  
  }
  public void heapify (Node parent)
  {
    Node leftChild;
	Node rightChild;
	leftChild.value = 2*parent.value+1;
    Node child = null;
	
  
  }
  
  

}