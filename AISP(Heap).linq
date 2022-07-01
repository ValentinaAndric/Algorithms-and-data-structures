<Query Kind="Program" />

void Main()
{
	
}

public class Heap
{
  private int[] array;
  private int count;
  private int Capacity = 32;
  private bool isMinHeap;

  public Heap (bool isMin = true)
  {
    count=0;
	isMinHeap= isMin;
	array = new int[Capacity];
  }
  public void add (int value)
  {
    if(count == array.Length)
	{ 
	  doubleSize();
	}
	array[count++] = value;
	buildHeap();
    
  }
  public int? remove()
  {
     if (count ==0)
	 {
	   return null;
	 }
	 int value = array [0];
	 array[0]= array [count-1];
	 count--;
	 heapify(0);
	 return value;
  }
  public void doubleSize()
  {
   int[] old = array;
   array = new int [array.Length * 2];
   Array.Copy(old,0,array,0,count);
  }
  
  public Heap(int[] array, bool isMin = true)
  {
     count = array.Length;
	 isMinHeap = isMin;
	 this.array = new int[array.Length];
	 Array.Copy(array,0, this.array,0,array.Length);
     buildHeap(); 
  }
  
  public void buildHeap()
  {
    for (int i =count/2; i>=0; i--)
	{
	  heapify(i);
	}
  }
  
  public void heapify(int parent)
  {
   int leftChild = 2*parent +1;
   int rightChild = leftChild+1;
   int child = -1;
   int temp;
   
   if (leftChild< count)
   { 
     child = leftChild;
   }
   if (rightChild<count && compare(array,leftChild,rightChild))
   {
     child = rightChild;
   }
   if (child != -1 && compare(array,parent,child))
   {
     temp = array[parent];
	 array[parent] = array[child];
	 array[child] = temp;
	 heapify(child);
   }
   
  }
  
  public bool compare (int [] array, int first, int second)
  {
    if (isMinHeap)
	{
	  return (array[first] - array[second])>0
	}
	else
	{
	   return (array[second]- array[first])>0;
	}
  
  }
  public int size()
  {
    return count;
  }
  public void print ()
  {
  for (int i =0; i<size(); i++)
  {
    Console.WriteLine (array[i]+ " ");
  }
  }
  
  public class HeapSort
  {
    public static void sort (int[] array, bool inc)
	{
	  Heap heap = new Heap (array , !inc);
	  for (int i =0; i< array.Length; i++)
	  {
	    array[array.Length - i - 1] = (int)heap.remove();
	  }
	  
	
	}
  }
}