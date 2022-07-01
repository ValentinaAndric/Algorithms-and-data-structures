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
	avl.PrintInOrder();
	avl.IsBalanced();
	avl.Delete(14);
	avl.PrintInOrder();
	avl.IsBalanced();
	
	int[] search = {14, 20};
	
	foreach (int item in search)
		if (avl.Find(item))
			Console.WriteLine($"{ item } found");
		else
			Console.WriteLine($"{ item } not found");
	
}

public class Avl
{
	private Node root;
	
	private class Node
	{
		internal Node lChild;
		internal Node rChild;
		internal Node parent;
		internal int value;
		
		public Node(int value, Node rChild, Node lChild, Node parent)
		{
			this.value = value;
			this.rChild = rChild;
			this.lChild = lChild;
			this.parent = parent;
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
		{
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
				if (current.rChild != null) //ako postoji child onda sl cvor prevezati na parent od ovoga sto se brise
				{
					parent = current.rChild;
					while (parent.lChild != null)
	                {
	                    parent = parent.lChild; //trazimo minimalni element u desnom podstablu
	                }
	                current.value = parent.value; //upisujemo minimalni element na mesto elementa koji brisemo
	                current.rChild = DeleteNode(current.rChild, parent.value); //pozivamo se opet da obrisemo ovaj minimalni element koji je otisao gore
					if (GetBalanceFactor(current) == 2) //rebalansiranje ako je potrebno
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
			else if (value < current.value) //idemo levo
			{
				current.lChild = DeleteNode(current.lChild, value);
                if (GetBalanceFactor(current) == -2)//here
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
			else //value > current.value //idemo desno
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
	
	//Vrsi balansiranje stabla u datom cvoru
	private Node BalanceTree(Node current)
	{
		int balanceFactor = GetBalanceFactor(current);
		
		if (balanceFactor > 1) //Levo podstablo je to koje je vise
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
		else if (balanceFactor < -1) //Desno podstablo je to koje je vise
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
	
	//Vraca faktor balansiranosti za dati cvor
	private int GetBalanceFactor(Node current)
	{
		int lSubtreeHeight = GetHeight(current.lChild);
		int rSubtreeHeight = GetHeight(current.rChild);
		return lSubtreeHeight - rSubtreeHeight;
	}
	
	//Rekurzijom racuna visinu levog i desnog podstabla
	private int GetHeight(Node current)
    {
        int height = 0;
        if (current != null)
        {
            int left = GetHeight(current.lChild);
            int right = GetHeight(current.rChild);
            int m = left > right ? left : right;
            height = m + 1; //Dodaje se 1 zbog current cvora (parent)
        }
        return height;
    }
	
	//Metode za 4 slucaja rotacije
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
	
	//Display tree
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
	
	//Temp metode za proveru stabla - ovo se ne radi na casu	
	public void IsBalanced()
	{
		if (IsBalanced(root))
			Console.WriteLine("Tree is balanced");
		else
			Console.WriteLine("Tree is not balanced");
	}
	
	private bool IsBalanced(Node node) 
    { 
        int lh;
  
        int rh; 
		
        if (node == null) 
        { 
            return true; 
        } 
          
        lh = Height(node.lChild); 
        rh = Height(node.rChild); 
  
        if (Math.Abs(lh - rh) <= 1 && IsBalanced(node.lChild) && IsBalanced(node.rChild)) 
        { 
            return true; 
        } 
        return false; 
    } 
  
    private int Height(Node node) 
    { 
        
        if (node == null) 
        { 
            return 0; 
        } 
  
        return 1 + Math.Max(Height(node.lChild), Height(node.rChild)); 
    } 
}