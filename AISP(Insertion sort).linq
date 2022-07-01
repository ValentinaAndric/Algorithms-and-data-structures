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
	InsertionSort.sort(arr);
	
	Console.WriteLine ();
	Console.WriteLine ("Sorted array");
	
	foreach (long i in arr)
	{
	 Console.Write(i + " ");
	}
}

public class InsertionSort
{
	public static void sort(long[] arr)
	{
		int size = arr.Length;
		int j;
		long tmp;
		
		for (int i=1; i < size; i++)
		{
			tmp=arr[i];
			for (j=i; j > 0 && arr[j-1] > tmp ; j--)
			{
				arr[j] = arr[j-1];
			}
			arr[j] = tmp;
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

