<Query Kind="Program" />

void Main()
{
	
}

public class MergeSort
{
private static void merge (long[] arr, long[] tmpArray, int lowerIndex, int middleIndex, int upperIndex)
{
int lowerStart = lowerIndex;
int lowerStop = middleIndex;
int upperStart = middleIndex + 1;
int upperStop = upperIndex;
int count = lowerIndex;

while (lowerStart <= lowerStop && upperStart <= upperStop)
{
if (arr[lowerStart]<arr[upperStart])
{
tmpArray[count++]=arr[lowerStart++];
}
else
{
tmpArray[count++]= arr[upperStart++];
}
}
while (lowerStart <= lowerStop)
{
tmpArray[count++] =arr[lowerStart++];
}
while (upperStart <= upperStop)
{
tmpArray[count++] = arr[upperStart++];
}
for (int i = lowerIndex; i<=upperIndex; i++)
{
arr[i]= tmpArray[i];
}
}
}