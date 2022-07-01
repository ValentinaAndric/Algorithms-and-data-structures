<Query Kind="Program" />

void Main()
{  
    int n;
	long m;
	int number;
    Console.WriteLine("Unesite duzinu niza");
	n=int.Parse(Console.ReadLine());
	SortedArrayGenerator sortedArray = new SortedArrayGenerator();	
	long[] array = new long[n];
	array= sortedArray.GenerateSortedArray(n);
	foreach (long i in array)
	{
	Console.WriteLine(i);
	}
	Console.WriteLine("Unesite broj koji zelite da se pretrazi u nizu");
	m=long.Parse(Console.ReadLine());
	number = BinarySearch.search(array, array.Length, m);
	if(number == 0)
	{
	   Console.WriteLine("Dati broj ne postoji u nizu");
	}
	else
	{
	   Console.WriteLine(number);
	}
	
	
	
}

public class BinarySearch
{
//Za binary search niz uvek mora da bude sortiran
public static int search (long[] array, int size, long value) //Kad je metoda staticka pozivamo je bez kreiranja objekta klase(pozivanja klase)
{

  int low = 0; //Najniža vrednost u nizu tj nulti element
  int height= size-1; // I poslednji element koji se dobija oduzimanjem od ukupne dužine niza
  int middle; //sredina
  while(low <= height) //Kako se te vrednosti pomeraju dolazimo do kraja niza kad bude npr 7==7 to je onda false i vraca 0
  {
   middle = (low +height) /2; //Delimo niz na dva dela
   if(array[middle] == value) //Ako je sredina niza baš ta vrednost što u jednom momentu i mora da bude
   {
      return middle; //I vraćamo taj broj koji ćemo kasnije i da ispisujemo
   }
   else if (array[middle]< value) //Ukoliko je ta vrednost koju tražimo veća od sredine onda će najniža vrednost biti sredina +1
   {
   low = middle +1;
   }
   else  //Ukoliko je manja menjamo najvišu vrednost koja će biti sredina -1
   {
    height = middle-1;
   }
  }
  return 0; //Ukoliko nije nijedan od toda onda vrećamo 0 i na osnovu toga će se ispisivati odg poruka

}



}
public class SortedArrayGenerator
{
	public long[] GenerateSortedArray(long n)
	{
		RandomNumberGen random = new RandomNumberGen();
		long[] randomArray = new long[n];
		int counter = 0;
		int step = 13;
		int index = 0;
		
		while(index < n)
		{
			long num = random.Next();
			if(num > 50)
			{
				randomArray[index] = counter + num % step;
				index++;
			}
			counter = counter + step;
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