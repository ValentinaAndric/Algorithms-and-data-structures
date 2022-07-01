<Query Kind="Program" />

void Main()
{
	
}

public class Btree
{
   private int mindegree;
   private Node root;
   public class Node
   { 
     public  int [] Keys {get; set;}
	 public Node [] Children {get; set;}
	 public bool isLeaf {get; set;}
	 public int Size {get; set;}
	  
	  public Node (int degree)
	  { 
	     Keys = new int [(2*degree)-1];
		 Children = new Node [2*degree];
	  }
   
   }

   public Btree (int mindegree)
   { 
      this.mindegree = mindegree;
	  root = new Node (mindegree);
	  root.isLeaf = true;
   
   }
 public void Insert(int value)
 {
    InsertNode (root, value);
 
 }
private void InsertNode (Node current, int value)
{
  if(current.Size == (2*mindegree)-1)
  {
      InsertFull(current, value);
  }
  else
  {
    InsertNonFull(current,value);
  }
}

private void InsertFull (Node current, int value)
{
     Node newNode = new Node (mindegree);
	 newNode.isLeaf = false;
	 newNode.Size=0;
	 newNode.Children[0] = root;
	 root = newNode;
	 SplitChild (newNode,0);//Prosledjujemo roditelja koji je prazan i indeks starog ruta na koji treba da prevezemo
	 InsertNonFull(root,value);
	 
}
public void InsertNonFull (Node current, int value)
{
   int i = current.Size-1;
   if (current.isLeaf)
   {
     if (i>=0 && value<current.Keys[i])
	 { 
	     current.Keys[i+1]= current.Keys[i];
		 i=i-1;
	 }
   current.Keys[i+1] = value;
   current.Size = current.Size+1;
   }
   else//Ako to nije list i nije pun jer se nalazimo u non full
   { 
       while (i>=0 && value<current.Keys[i])//Da li vrednost treba da se doda na levo ili desno na osnovu toga uzimamo levi ili desni indeks
	   {
	      i-=1;
	   }
	   i+=1;
	   
	   if (current.Children[i].Size == (2*mindegree)-1)
	   {
	     SplitChild (current, i);
		 if (value > current.Keys[i])//Ako treba da se spustamo levo ili desno , za odg indeks ce se pozivati funkcija, to odredjujemo na osnovu vrednosti kljuca
		 {
		    i+=1;
		 }
	   
	   }
	   
	   InsertNonFull (current.Children[i], value);
   
   }

}

public void SplitChild(Node nonFullParent, int indexOfFullChildren)
{
 Node newNode = new Node (mindegree);
 Node fullChild = nonFullParent.Children[indexOfFullChildren];
 newNode.isLeaf = fullChild.isLeaf;
 newNode.Size=mindegree-1;
 
 for (int i=0; i<mindegree-1; i++)
 {
   newNode.Keys[i] = fullChild.Keys[i+ mindegree];
 }
 if(!fullChild.isLeaf)
 {
   for (int i=0; i<mindegree-1; i++)
   {
   
     newNode.Children[i]= fullChild.Children[i+mindegree];
   }
 }
 fullChild.Size = mindegree-1;
 for (int i = nonFullParent.Size; i==indexOfFullChildren+1; i--)
 {
    nonFullParent.Children[i+1] = nonFullParent.Children[i];
 }
 nonFullParent.Children[indexOfFullChildren+1]= newNode;
 for (int i = nonFullParent.Size-1; i==indexOfFullChildren; i--)//Ako je vrednot manja onda se trenutni kljuc mora pomeriti u desno da bi se dodao odgovarajuci kljuc na pocetak
 {
   nonFullParent.Keys[i+1] = nonFullParent.Keys[i];

 }
 nonFullParent.Keys[indexOfFullChildren]= fullChild.Keys[mindegree-1];
 nonFullParent.Size = nonFullParent.Size+1;
 for (int i =fullChild.Size; i<(2* mindegree)-1; i++)
 {
   fullChild.Keys[i] = 0;
   fullChild.Children[i+1]=null;
 }
}

public bool find (int value)
{
   Node result = findNode (root,value);
   if (result != null)
   {
     return true
   }
   return false;
   
}
public Node findNode (Node current, int value)
{
    int i = 0;
	while (i<= current.Size-1 && value > current.Keys[i])
	{
	 i++;
	}
	
	if (i<=current.Size-1 && value == current.Keys[i])
	{
	  return current;
	}
	else if (current.isLeaf)
	{
	  return null;
	}
	else
	{
	  return findNode(current.Children[i], value);
	}
   
   
}
}
