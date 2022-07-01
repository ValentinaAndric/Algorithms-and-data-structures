<Query Kind="Program" />

void Main()
{
	RandomArrayGenerator rnd = new RandomArrayGenerator();
	long[] array = rnd.GenerateRandomArray(10);
	Console.WriteLine("Nesortirani niz");
	foreach (long i in array)
	{
	  Console.Write (i+ " ");
	}
	BubbleSort.bubbleSort(array);
	
	Console.WriteLine();
	Console.WriteLine("Nesortirani niz");
	foreach (long i in array)
	{
	   Console.Write (i+ " ");
	}
	
}

public class BubbleSort
{
  public static void bubbleSort (long[] array)
  {  
     long temp;
	 int size = array.Length;
	 for (int i = size-1; i>0; i--)
	 {
	     for (int j=0; j<i; j++)
		 {
		    if (array[j] > array[j+1])
			{
			    temp=array[j];
			    array[j]= array[j+1];
				array[j+1]= temp;
			
			}
		 }
	 
	 }
  
    
  }


}

public class RandomArrayGenerator
{	
	public long[] GenerateRandomArray(long n)
	{
		RandomNumberGen random = new RandomNumberGen();
		long[] randomArray = new long[n];
		
		for(int i = 0; i < n; i++)
		{			
			randomArray[i] = random.Next();
		}		
		return randomArray;
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