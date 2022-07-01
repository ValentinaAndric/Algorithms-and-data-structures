<Query Kind="Program" />

void Main()
{
	int n;
	RandomArrayGen r = new RandomArrayGen();
	long[] array = new long[100000];
	array = r.GeneratedRandomArray(100000);
	foreach (long i in array)
	{
	  Console.WriteLine(i);
	}

	Console.WriteLine("Unesite broj koji zelite da se pretrazi");
	n= int.Parse(Console.ReadLine());
	for (int i=0; i< array.Length; i++)
	{
	   if (array[i] == n)
	   {
	     Console.WriteLine ("Broj se nalazi na poziciji " + i);
	   }
	   
	}
}

public class RandomArrayGen
{
   public long[] GeneratedRandomArray(long n)
   {
       long[] Array = new long[n];
	   RandomNumberGen rand = new RandomNumberGen();
	   for (int i =0; i<n; i++)
	   {  
	      Array[i] = rand.Next();
	   
	   }
	   return Array;	   
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
