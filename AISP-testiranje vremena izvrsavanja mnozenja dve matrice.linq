<Query Kind="Program" />

void Main()
{
	int n,m,p,q;	
	n= 1000;	
	m= 1000;	
	p= 1000;	
	q= 1000;
	RandomNumberGen random = new RandomNumberGen();
	
	
	int [,] matrix1 = new int [n,m];
	int [,] matrix2 = new int [p,q];
	int [,] matrix3 = new int [n,q];
	if (m==p)
	{
	 for (int i = 0; i<n; i++)
	 {
	  for (int j =0; j<m; j++)
	  {
	     
	  matrix1 [i,j]= (int)random.Next();
	  }
	  
	 }
	 
    for(int i=0; i<p; i++)
	{
	  for (int j=0; j<q; j++)
	  {
	   matrix2 [i,j] = (int)random.Next();
	  }
	  
	}
	for (int i=0; i<n; i++)
	{  for (int j=0; j<q; j++)
	{
	   	
	  for(int k=0; k<p; k++)
	  {
	    matrix3[i,j] += matrix1[i,k] * matrix2[k,i];
	  }
	  
	}
	
	}
	Console.WriteLine("Pomnozena matrica");
	for (int i=0; i<n; i++)
	{
	for(int j=0; j<q; j++)
	{
	 Console.Write(matrix3[i,j]+ "\t");
	}
	Console.WriteLine();	
	}
	}	
	else
	{
	Console.WriteLine("Broj kolona prve matrice mora biti jednak broju redova druge matrice");
	}
	
}

public class RandomNumberGen
{
   private long mod = 4294967296;
   private const long a = 214013; //prema istazivanju Microsofra definisane su ove konstante
   private const long c = 2531011;
   private long min = 0; // Ulazne vrednosti iz naseg zadatka
   private long max=100;
   private double seed;
   
   public RandomNumberGen()
   {
     seed= (long)DateTime.Now.Ticks % mod; //Ticks metoda daje neki deo sekunde u kom smo mi kliknuli i pretvaramo ga u long i skaliramo na nas opseg
   }
   
   public RandomNumberGen(long min, long max) : this()
   {
       this.min = min; //Setuje vrednosti min i max ali mi smo ih vec uneli u programu ali mozemo obezbediti da ih korisnik sam unosi
	   this.max = max;
   
   }
   
   public long Next()
   { 
      seed = (a * seed + c) % mod; //Po formuli za dobijanje narednog broja u odnosu na nas pocetni seed koji smo dobili kreirajuci objekat pozivom konstruktora putem kljucne reci new
	  return (long) ((seed/ (mod -1)) * (max - min) + min); //Skalira na nas opseg od 0-100
   }

}
