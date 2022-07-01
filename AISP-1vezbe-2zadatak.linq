<Query Kind="Program" />

void Main()
{
	int n,m;
	Console.WriteLine("Unesite broj redova matrice");
	n= int.Parse(Console.ReadLine());
	Console.WriteLine("Unesite broj kolona matrice");
	m= int.Parse(Console.ReadLine());
	int[,] matrica= new int[n,m];
	int[,] matrica2= new int[n,m];
	
	if(n==m)
	{
	Console.WriteLine("Unesite elemente matrice");
	for (int i =0; i<n; i++)
	{
	for(int j=0; j<m; j++)
	{
	  matrica[i,j]= int.Parse(Console.ReadLine());
	}
	}
	Console.WriteLine("Vasa matrica izgleda");
	ispisi(matrica, n,m);
	Console.WriteLine ("Transponovana matrica");
	{
	 for (int i =0; i<m; i++)
	 {
	  for (int j=0; j<n; j++)
	  {
	    matrica2[i,j]=matrica[j,i];
	  }
	  
	 }
	 Console.WriteLine("Vasa transponovana matrica izgleda");
	ispisi (matrica2, n,m);
	
	}	
	}
	else{
	Console.WriteLine("Mozemo transponovati samo kvadratne matrice stoga unesite isti broj kolona i vrsta!!!");
	}
	}

   void ispisi (int [,] matr, int n, int m)
{ 
     for (int i =0; i<m; i++)
	 {
	  for (int j=0; j<n; j++)
	  {
	   Console.Write(matr[i,j] + "\t");
	  }
	   Console.WriteLine();
    }
}

// You can define other methods, fields, classes and namespaces here
