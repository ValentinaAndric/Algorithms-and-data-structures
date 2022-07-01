<Query Kind="Program" />

void Main()
{
  RandomNumberGen random = new RandomNumberGen();
  Console.WriteLine(random.Next());
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

// You can define other methods, fields, classes and namespaces here
