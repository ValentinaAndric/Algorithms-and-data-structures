<Query Kind="Program" />

void Main()
{
	HashingChaining hsh = new HashingChaining ();
	hsh.Add(5);
	hsh.Add(6);
	hsh.Add (324);
	hsh.Print();
}
public class Dictionary
{
  HashingChaining hc;
  
  public Dictionary ()
  { 
      hc = new HashingChaining (7);
  }
  
  public void Add (int value)
  {
     CheckLoadFactor ();
	 hc.Add(value);
  
  }
  public bool Remove (int value)
  {
    bool result = hc.Remove (value);
	if (result)
	{
	  CheckLoadFactor();
	}
	return result;
  }
  
  public bool Find (int value)
  {
   return hc.Find (value);
  }
  
  public void print ()
  {
    hc.Print();
  }

public void CheckLoadFactor ()
{
  if (hc.N > hc.tableSize)
  {
    HashingChaining doublehc = new HashingChaining (hc.tableSize*2);
	RehashToNewTable(doublehc);
	hc = doublehc;
  }
  else if (hc.N + 1 < hc.tableSize/4)
  {
    HashingChaining shrunkenHashTable = new HashingChaining (hc.tableSize/4)
	RehashToNewTable(shrunkenHashTable);
	hc = shrunkenHashTable;
  
  }

}

public void RehashToNewTable(HashingChaining hashTable)
{
    for (int i =0; i<hc.tableSize; i++)
	{  
	   var temp = hc.listArray[i];//Uzimamo pojedinacne slotove sa nizovima 
	   while (temp!=null)//Dok god ne dodjemo do kraja slota upisuj te vrednosti, zatim predji na drugi slot
	   {
	     hashTable.Add(temp.value);
		 temp = temp.next;
	   
	   }
	 
	
	}
  
  
}
}
public class HashingChaining 
{

  public Node[] listArray;
  public int tableSize;
  public int N;
  
  public class Node
  {
    public Node next;
	public int value;
	 public Node(int value, Node next)
	 {
	   this.value = value;
	   this.next = next;
	 }
  }
  
  public HashingChaining()
  {
     tableSize = 512;
	 listArray =  new Node [tableSize];
  
  }
  public HashingChaining(int tableSize)
  {
     this.tableSize = tableSize;
	 listArray= new Node [tableSize];
  
  }
  
  public int ComputeHash (int key)
  {
    return key%tableSize;
  }
  
  public void Add (int value)
  { 
    int index = ComputeHash (value);
	listArray[index] = new Node (value, listArray[index]);
	N+=1;
  }
  
  public bool Remove (int value)
  {
     int index = ComputeHash (value);
	 Node head = listArray[index];
	 Node nextNode  = listArray[index];
	 if (head != null && head.value == value)
	 {
	   listArray[index] = head.next;//Vrednost pocetka se ne cuva u headu nego u listi, u listArray
	   N-=1;
	   return true; 
	 }
	 
	 while (head != null)
	 {
	    nextNode = head.next;
	    if (nextNode != null && nextNode.value == value)
		{
		   head.next = nextNode.next;
		   return true;
		}
		else
		{
		  head = nextNode;//Od glave proveravamo da li je sledeci da bi u svakom momenetu imali taj sledeci od nextNoda na koji cemo prevezati
		}
	 
	 }
     return false;
  }
  
  public bool Find (int value)
  {
     int index = ComputeHash (value);
	 Node head = listArray[index];
	 
	while (head != null)
	{
	  if (head. value == value)
	  {
	    return true;
	  }
	    head = head.next;
	}
	return false;
    
  }
  
  public void Print()
    {
        for (int i = 0; i < tableSize; i++)
        {
            Console.Write($"\n Printing for index value: { i } \n List of values:");
            Node head = listArray[i];
            while(head != null)
            {
                Console.Write($" { head.value } ");
                head = head.next;
            }
        }
    }



}
