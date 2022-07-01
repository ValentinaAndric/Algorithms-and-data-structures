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
public class Dictionary
{
  HashTableOpenAdressing ht;
  public Dictionary ()
  {
     ht = new HashTableOpenAdressing (7);
  }
  public void Add (int value)
  {
     CheckLoadFactor ();
	 ht.Add(value);
  }
  
  public bool Remove (int value)
  {
    bool result = ht.Remove (value);
    if (result)
	{
	  CheckLoadFactor();
	}
	return result;
  }
  
  public bool Find (int value)
  {
    return ht.Find(value);
  }
  public void Print ()
  {
     ht.Print();
  }
  
  public void CheckLoadFactor ()
  {
    double loadFactor = ((double)ht.N+1)% (double)ht.tableSize;
	if (loadFactor> 0.5)
	{
	   HashTableOpenAdressing doubleht = new HashTableOpenAdressing(ht.tableSize*2);
	   RehashToNewTable(doubleht);
	   ht = doubleht;
	
	}
	else if (loadFactor < 0.25)
	{ 
	   HashTableOpenAdressing shrunkenht = new HashTableOpenAdressing(ht.tableSize/4);
	   RehashToNewTable(shrunkenht);
	   ht = shrunkenht;
	}
  
  }
    public void RehashToNewTable (HashTableOpenAdressing hc)
    {
      for (int i=0; i< ht.tableSize; i++)
	  {
	     if (ht.hashTable[i] != null && !ht.hashTable[i].deleted)
	     {   
		     hc.Add(ht.hashTable[i].value);
		  
		 }
	  
	  }

    }

}

public class HashTableOpenAdressing
{ 
  public int tableSize;
  public Node[] hashTable;
  public int N;
  
   
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
		  N+=1;
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
		   N-=1;
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
