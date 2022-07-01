<Query Kind="Program" />

void Main()
{	
	Avl avl = new Avl();
	avl.Insert(1);
	avl.Insert(3);
	avl.Insert(7);
	avl.Insert(10);
	avl.Insert(14);
	avl.Insert(18);
	avl.print();	
	
}

public class Avl
{
	private Node root;
	static readonly int COUNT = 10; 

	private class Node
	{
		internal Node lChild;
		internal Node rChild;
		internal Node parent;
		internal int value;
		internal int height;
		
		public Node(int value, Node rChild, Node lChild, Node parent)
		{
			this.value = value;
			this.rChild = rChild;
			this.lChild = lChild;
			this.parent = parent;
			this.height = 1;
			
		}
		
	}	
		
	public Avl(){}
	
	public void Insert(int value)
    {
        root = InsertNode(root, value, null);
    }
	
	private Node InsertNode(Node current, int value, Node parent)
	{
		if (current == null)
		{
			current = new Node(value, null, null, parent);
		
		}
		else
		{   current.height ++;
			if (current.value > value)
			{
				current.lChild = InsertNode(current.lChild, value, current);				
			}
			else
			{
				current.rChild = InsertNode(current.rChild, value, current);				
			}
			current = BalanceTree(current);
		}
		
		return current;
	}
	
	public bool Find(int value)
    {
        Node result = FindNode(root, value);
		if (result != null)
		{
			return true;
		}
		return false;
    }
	
    private Node FindNode(Node current, int value)
    {	
		Node temp = current;
		
		while (temp != null)
		{
			if (temp.value == value)
			{
				return temp;
			}
			
			if (value < temp.value)
			{
				temp = temp.lChild;
			}
			else
			{
				temp = temp.rChild;
			}
		}	
		return null;
    }
	
	public void Delete(int value)
	{
		root = DeleteNode(root, value);
	}
	
	private Node DeleteNode(Node current, int value)
	{
		Node parent = null;
		
		if (current != null)
		{
			if (value == current.value)
			{
				if (current.rChild != null) 
				{
					parent = current.rChild;
					while (parent.lChild != null)
	                {
	                    parent = parent.lChild; 
	                }
	                current.value = parent.value; 
	                current.rChild = DeleteNode(current.rChild, parent.value); 
					if (GetBalanceFactor(current) == 2) 
                    {
                        if (GetBalanceFactor(current.lChild) >= 0)
                        {
                            current = RotateR(current);
                        }
                        else 
						{ 
							current = DoubleRotateRL(current); 
						}
                    }
				}
				else
				{
					return current.lChild;
				}
			}
			else if (value < current.value) 
			{
				current.lChild = DeleteNode(current.lChild, value);
                if (GetBalanceFactor(current) == -2)
                {
                    if (GetBalanceFactor(current.rChild) <= 0)
                    {
                        current = RotateL(current);
                    }
                    else
                    {
                        current = DoubleRotateLR(current);
                    }
                }
			}
			else 
			{
				current.rChild = DeleteNode(current.rChild, value);
                if (GetBalanceFactor(current) == 2)
                {
                    if (GetBalanceFactor(current.lChild) >= 0)
                    {
                        current = RotateR(current);
                    }
                    else
                    {
                        current = DoubleRotateRL(current);
                    }
                }
			}
		}
		return current;
	}
	
	
	private Node BalanceTree(Node current)
	{
		int balanceFactor = GetBalanceFactor(current);
		
		if (balanceFactor > 1) 
		{
			if (GetBalanceFactor(current.lChild) > 0)
			{
				current = RotateR(current);
			}
			else
			{
				current = DoubleRotateRL(current);
			}
		}
		else if (balanceFactor < -1) 
		{
			if (GetBalanceFactor(current.rChild) > 0)
			{
				current = DoubleRotateLR(current);
			}
			else
			{
				current = RotateL(current);
			}
		}
		return current;
	}
	
	
	private int GetBalanceFactor(Node current)
	{
		int lSubtreeHeight = GetHeight(current.lChild);
		int rSubtreeHeight = GetHeight(current.rChild);
		return lSubtreeHeight - rSubtreeHeight;
	}
	
	
	private int GetHeight(Node current)
    {
        int height = 0;
        if (current != null)
        {
            int left = GetHeight(current.lChild);
            int right = GetHeight(current.rChild);
            int m = left > right ? left : right;
            height = m + 1;
        }
        return height;
    }
	
	
	private Node RotateL(Node parent)
	{
		Node pivot = parent.rChild;
		parent.rChild = pivot.lChild;
		pivot.parent = parent.parent;
		parent.parent = pivot;

		if (parent.rChild != null)
        {
			parent.rChild.parent = parent;
		}
		pivot.lChild = parent;
		return pivot;
	}
	private Node RotateR(Node parent)
	{
		Node pivot = parent.lChild;
		parent.lChild = pivot.rChild;
		pivot.parent = parent.parent;
		parent.parent = pivot;

		if (parent.lChild != null)
		{
			parent.lChild.parent = parent;
		}

		pivot.rChild = parent;
		return pivot;
	}
    private Node DoubleRotateRL(Node parent)
    {
        Node pivot = parent.lChild;
        parent.lChild = RotateR(pivot);
        return RotateL(parent);
    }
    private Node DoubleRotateLR(Node parent)
    {
        Node pivot = parent.rChild;
        parent.rChild = RotateL(pivot);
        return RotateR(parent);
    }	
	
	
	public void PrintInOrder()
    {            
        InOrderDisplay(root);
        Console.WriteLine();
    }
    private void InOrderDisplay(Node current)
    {
        if (current != null)
        {
            InOrderDisplay(current.lChild);
            Console.Write($"{current.value} ");
            InOrderDisplay(current.rChild);
        }
    }
	
	private void print2(Node curr, int space) 
{  
    if (curr == null) 
        return; 
		
    space += COUNT; 
   
    print2(curr.rChild, space); 
 
    Console.Write("\n"); 
    for (int i = COUNT; i < space; i++) 
        Console.Write(" "); 
    Console.Write(curr.value + "(" +curr.height+ ")"+ "\n"); 
  
    print2(curr.lChild, space); 
} 
public void print() 
{  
    print2(root, 0); 
} 

public int Rank(int t)
	{
		Node curr = root;
		int sumOfSubNodes = 0;
		
		while (curr != null)
		{
			if (curr.value == t)
			{
				return curr.height;
			}
			else if (curr.value > t)
			{
				if (curr.rChild != null)
				{
					sumOfSubNodes += curr.rChild.height;
				}	
				else
				{
					sumOfSubNodes += curr.height;
				}
				curr = curr.lChild;
			}
			else
			{
				if (curr.lChild != null)
				{
					sumOfSubNodes += curr.lChild.height;
				}
				else
				{
					sumOfSubNodes += curr.height;
				}
				
				curr = curr.rChild;
			}
		}
		return sumOfSubNodes;
	}
 
}
	

