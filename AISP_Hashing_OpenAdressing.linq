<Query Kind="Program" />

void Main()
{
	HashTableOpenAdressing hsh = new HashTableOpenAdressing (10);
	hsh.Add(5);
	hsh.Add(320);
	hsh.Add(480);
	hsh.Add(500);
	hsh.Print();
}
public class HashTableOpenAdressing
{ 
  private int tableSize;
  private Node[] hashTable;
   
  public class Node 
  {
     public int value;
	 public bool deleted { get; set; }
     public Node (int value)
	 {
	  this.value = value;
	  this.deleted = false; 
	 }
  }
  
  public HashTableOpenAdressing (int size)
  {
  
    this.tableSize = size;
	hashTable = new Node [size];
  }
   
   public int ComputeHash (int key)
   {
     return key % tableSize;
   }
  
  public int FindNextSlot (int key, int i)
  {
    return (key+i) % tableSize;
  
  }
  
  public bool Add (int value)
  {  
     int hash = ComputeHash (value);
	 
	 for (int i=0; i< tableSize; i++)
	 {
	    if (hashTable[hash] == null || hashTable[hash].deleted)
		{
		  hashTable[hash] = new Node (value);
		  return true;
		}
		  hash = FindNextSlot (value, i);
	 }
	 return false;
  
  }
  
  public bool Remove (int value)
  {
      int hash = ComputeHash (value);
	  for (int i =0; i< tableSize; i++)
	  {
	  
	      if (hashTable[hash] == null)
		  {
		     return false;
		  }
	   else if (hashTable[hash].value == value)
		{
		   hashTable[value].deleted = true;
		   return true;
		}
		else
		{
		   hash = FindNextSlot (value,i);
		}
	  
	  }
  return false;
  }
  
  public bool Find (int value)
  {
     int hash = ComputeHash(value);
	 for (int i =0; i<tableSize; i++)
	 {
	    if (hashTable[hash].value == value)//Ako nije vrednost na tom slotu znaci da je pre dodavanja ove vrednosti na mesto gde je trebala da se doda bila neka vrednost pa se onda tek u drugoj iteraciji dodalo i onda ce se naci na drugoj poziciji
		{
		   return true;
		}
		else if (hashTable[hash] == null)
		{
		  return false;
		}
		
		FindNextSlot(value,i);
	 }
  return false;
  }
  
  public void Print ()
  {
    for (int i =0; i< tableSize; i++)
	{
	   if (hashTable[i] != null)
	   {
	  Console.WriteLine ("Slot " + i + " Value of slot: "+ hashTable[i].value);
	  }
	}
  
  }
  
}
