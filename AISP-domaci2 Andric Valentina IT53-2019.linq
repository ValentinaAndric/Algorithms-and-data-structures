<Query Kind="Program" />

void Main()
{  
   
    int n,m;
	Console.WriteLine ("Enter the dimensions of the matrix");
	n=int.Parse (Console.ReadLine());
	RandomMatrixGen rnd = new RandomMatrixGen();
    Console.WriteLine(rnd.GenerateRandomMatrix(n));
	 
}

public class RandomMatrixGen
{
  public long[,] GenerateRandomMatrix (long n)
  {
       long[,] matrix = new long[n,n];
	   RandomNumberGen random = new RandomNumberGen();
	   for (int i=0; i<n; i++)
	   {
	     for (int j=0; j<n; j++)
         {
		    matrix [i,j] = random.Next();
         }	   
	   }
	   return matrix;     
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
