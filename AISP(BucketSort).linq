<Query Kind="Program" />

void Main()
{

RandomArrayGenerator rnd = new RandomArrayGenerator();
	long [] arr = rnd.GenerateRandomArray(10);
	Console.WriteLine("Random array");
	foreach (long i in arr)
	{
	  Console.Write (i+ " ");
	}
	
	BucketSort.bucketSort(arr,0,100);
	Console.WriteLine ();
	Console.WriteLine ("Sorted array");
	
	foreach (long i in arr)
	{
	 Console.Write(i + " ");
	}
	
}

public class BucketSort 
{
 public static void bucketSort(long[] array, long lowerRange, long upperRange)
 {  long i,j;
    
    long[] count = new long[upperRange - lowerRange];
	
	for (i=0; i<upperRange; i++)
	{
	  count[i]=0;
	}
    for (i = 0; i<array.Length; i++)
	   {
	     count[array[i]-lowerRange]++;
	   }
	for (i=0,j=0; j<upperRange; ++j)
	  {
	    for (long k = count[j]; k>0;--k)
		{
		  array[i++]= lowerRange + j;
		  
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


