<Query Kind="Program" />

void Main()
{
	int n,m,p,q;
	Console.WriteLine("Unesite broj redova prve matrice");
	n= int.Parse(Console.ReadLine());
	Console.WriteLine("Unesite broj kolona prve matrice");
	m= int.Parse(Console.ReadLine());
	Console.WriteLine("Unesite broj redova druge matrice");
	p=int.Parse(Console.ReadLine());
	Console.WriteLine("Unesite broj kolona druge matrice");
	q=int.Parse(Console.ReadLine());
	
	int [,] matrix1 = new int [n,m];
	int [,] matrix2 = new int [p,q];
	 int[,] matrix3 = new int [n,q];
	if (m==p)
	{
	Console.WriteLine("Unesite elemente prve matrice");
	 for (int i = 0; i<n; i++)
	 {
	  for (int j =0; j<m; j++)
	  {
	     
	  matrix1 [i,j]=int.Parse(Console.ReadLine());
	  }
	  
	 }
	 Console.WriteLine("Unesite elememte druge matrice");
    for(int i=0; i<p; i++)
	{
	  for (int j=0; j<q; j++)
	  {
	   matrix2 [i,j] = int.Parse(Console.ReadLine());
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

// You can define other methods, fields, classes and namespaces here
