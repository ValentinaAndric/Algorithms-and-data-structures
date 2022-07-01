<Query Kind="Program" />

void Main()
{
	RandomSortedArrayGen rnd = new RandomSortedArrayGen();
	Console.Write(rnd.GenerateSortedArray(5));
	 
	
}

public class RandomSortedArrayGen
{
   public long[] GenerateSortedArray(int n)
   {  long [] sortedArray = new long [n];
      RandomNumberGen random = new RandomNumberGen();
       for (int i=0; i< n; i++)
	   {
	       sortedArray[i] = random.Next();
	   }
	   Sortiraj (sortedArray, n);
	   
       return sortedArray;
   }
public void Sortiraj (long [] array, int n)
 {
  long num;
        for (int i=0; i<n-1; i++)
		{
		   if (array [i] > array [i+1])
		   {
		      num = array[i];
			  array[i] = array[i+1];
			  array[i+1] = num;
			  
		   }
		
		}
		
 }
}
 



public class RandomNumberGen
{
	private long mod = 4294967296;
    private const long a = 214013;
    private const long c = 2531011;
	private long min = 0;
	private long max = 100;
    private double seed;
	
	public RandomNumberGen()
	{
		seed = (long)DateTime.Now.Ticks % mod;
	}
	
	public RandomNumberGen(long min, long max) : this()
	{
		this.min = min;
		this.max = max;
	}
	
	public long Next()
	{
		seed = ((a * seed) + c) % mod;
		return (long)((seed / (mod - 1)) * (max - min) + min);
	}
}
