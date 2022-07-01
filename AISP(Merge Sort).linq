<Query Kind="Program" />

void Main()
{
	
	
}

public static void merge (long[] array, long[] tempArray, int lowerIndex, int middleIndex, int upperIndex)
{
  int lowerStart = lowerIndex;
  int lowerStop = middleIndex;
  int upperStart = middleIndex + 1;
  int upperStop = upperIndex;
  int count = lowerIndex;
  while (lowerStart <= lowerStop && upperStart<= upperStop)
  {
    if (array[lowerStart] < array [upperStart])
	{
	   tempArray[count ++] = array[lowerStart++];
	}
	else 
	{
	   tempArray[count++] = array[upperStart ++];
	}
  }
  while (array[lowerStart] <= array[lowerStop])
  {
    tempArray[count++] = array[lowerStart++];
   
  }
  while (array[upperStart] <= array[upperStop])
  {
    tempArray[count++] = array[upperStart++];  
  }
  for (int i = lowerIndex; i<upperIndex; i++)
  {
    array[i] = tempArray[i];
  }

}

public static void mergeSort (long[] array, long[] tempArray, int lowerIndex, int upperIndex)
{
   if (lowerIndex >= upperIndex)
   return;
   int middleIndex = (lowerIndex + upperIndex)/2;
   mergeSort (array,tempArray,lowerIndex, middleIndex);
   mergeSort (array,tempArray,middleIndex+1, upperIndex);
   merge (array, tempArray, lowerIndex, middleIndex, upperIndex);
   
}

public static void sort (long[]array)
{
  int size = array.Length;
  long[] tempArray= new long[size];
  mergeSort (array, tempArray,0, size-1);
  

}