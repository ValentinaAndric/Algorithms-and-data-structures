<Query Kind="Program" />

void Main()
{
	String txt = "ALGORITMIISTRUKTUREPODATAKA2020/2021"; 
    String pat = "POD"; 
        
    int q = 20;
        
    KarpRabinAlgorithm.search(pat, txt, q); 
}

public class KarpRabinAlgorithm
{
	private readonly static int d = 256;
	
	public static void search(String pattern, String text, int q)
	{
		int M = pattern.Length; 
        int N = text.Length; 
        int i, j; 
        int patternHash = 0; // Hash vrednost obrasca koji se trazi 
        int textHash = 0; // Hash vrednost svakog prozora
        int h = 1; 
      
		// Racunanje parametra h
        for (i = 0; i < M-1; i++)
		{
            h = (h * d) % q; 
      	}
	  
		// Racunanje Hash vrednosti obrasca i prvog prozora u tekstu
        for (i = 0; i < M; i++) 
        { 
            patternHash = (d * patternHash + pattern[i]) % q; 
            textHash = (d * textHash + text[i]) % q; 
        }
      
		// Prolazak kroz svaki pojedinacni prozor u tekstu
        for (i = 0; i <= N - M; i++) 
        { 
			// Proveravanje da li se Hash-ovane vrednosti obrasca i trenutnog prozora poklapaju
			// U slucaju poklapanja Hash vrednosti neophodno je proveriti karaktere jedan po jedan
            if ( patternHash == textHash ) 
            { 
                // Proveravanje pojedinacnih karaktera
                for (j = 0; j < M; j++) 
                { 
                    if (text[i + j] != pattern[j])
					{
                        break; 
                	}
				} 
      
                // p == t and pat[0...M-1] = txt[i, i+1, ...i+M-1]
				// Ukoliko su svi karakteri obrasca identicni kao karakteri trenutnog prozora, obrazac je pronadjen
                if (j == M)
				{
                    Console.WriteLine("Pattern found at index " + i); 
            	}
			} 
   
			// Racunanje hash vrednosti narednog prozora, tj. brisanje prve cifre i dodavanje nove na kraj prozora
			// Ponovno racunanje Hash vrednosti novog prozora
            if ( i < N - M ) 
            { 
                textHash = (d * (textHash - text[i] * h) + text[i + M]) % q; 
      
                // Konverzija u slucaju da Rehash funkcija vrati negativan broj
                if (textHash < 0)
				{
                	textHash = (textHash + q); 
            	}
			} 
        }
	}
}