<Query Kind="Program" />

void Main()
{
	int[] array = new int[] {1,8,9,11,12,17};
	BST bst = new BST (array);
	bst.printInOrder();
	
}

public class BST
{
  private Node root;
	
	private class Node
	{
		internal int value;
		internal Node lChild;
		internal Node rChild;
		
		public Node(int value, Node left, Node right)
		{
			this.value = value;
			lChild = left;
			rChild = right;
		}
		
		public Node(int value)
		{
			this.value = value;
			lChild = null;
			rChild = null;
		}
	}
  public BST (int[] array)
  {
     root = CreateBinarySearchTree(array, 0, array.Length-1);
  
  }
  private Node CreateBinarySearchTree(int[] array,int start, int end)
  {
     Node curr = null;
	 if(start>end)
	 {
	    return null;
	 
	 }
	 int mid = (start+end)/2;
	 curr = new Node (array[mid]);
	 curr.lChild = CreateBinarySearchTree(array, start, mid-1);
	 curr.rChild = CreateBinarySearchTree(array,mid+1,end);
	 
	 return curr;
  
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
 
}