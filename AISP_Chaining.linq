<Query Kind="Program" />

void Main()
{
	HashingChaining hsh = new HashingChaining ();
	hsh.Add(5);
	hsh.Add(6);
	hsh.Add (324);
	hsh.Print();
}
public class HashingChaining 
{

  private Node[] listArray;
  private int tableSize;
  
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
  }
  
  public bool Remove (int value)
  {
     int index = ComputeHash (value);
	 Node head = listArray[index];
	 Node nextNode  = listArray[index];
	 if (head != null && head.value == value)
	 {
	   listArray[index] = head.next;//Vrednost pocetka se ne cuva u headu nego u listi, u listArray
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
