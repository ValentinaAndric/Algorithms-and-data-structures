<Query Kind="Program" />

void Main()
{
    int m,n;
	Console.WriteLine("Unesite broj redova matrice");
	m= int.Parse(Console.ReadLine());
	Console.WriteLine("Unesite broj kolona matrice");
	n= int.Parse(Console.ReadLine());
	int [,] matrica = new int[m,n];
	
	Console.WriteLine("Unesite elemente matrice");
	for (int i=0; i<m; i++)
	{
	for (int j=0; j<n; j++)
	{
	   matrica[i,j] =int.Parse(Console.ReadLine());
	}
	}
	
	Console.WriteLine("Vasa matrica izgleda:");
	for (int i =0; i<m; i++)
	{
	  for(int j=0; j<n; j++)
	  {
	    Console.Write(""+ matrica[i,j] +"\t");
	  }
	  Console.WriteLine();
	}	
	
	}

// You can define other methods, fields, classes and namespaces here
