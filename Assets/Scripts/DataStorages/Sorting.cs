using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Sorting
{

    public static int[] SwapSorting(int[] sourceArray, bool isAscending)
    {
        bool sorted = false;
        while (sorted == false)
        {
            sorted = true;
            for (int currentIndex = 1; currentIndex < sourceArray.Length; currentIndex++)
            {
                if ((sourceArray[currentIndex] < sourceArray[currentIndex - 1] && isAscending) || (sourceArray[currentIndex] > sourceArray[currentIndex - 1] && !isAscending))
                { //swap it behind
                    sourceArray = SwapElementsOfArray(sourceArray, currentIndex, currentIndex - 1);
                    sorted = false;
                    break; //start from beginning;
                }
            }
        }

        return sourceArray;
    }

    private static int[] SwapElementsOfArray(int[] sourceArray, int indexToSwap1, int indexToSwap2)
    {
        int temp = sourceArray[indexToSwap1];

        sourceArray[indexToSwap1] = sourceArray[indexToSwap2];
        sourceArray[indexToSwap2] = temp;

        return sourceArray;
    }
    private static int[] ChangeIndexOfElementInArray(int[] sourceArray, int oldIndexOfElement, int newIndex)
    {
        int[] newArray = new int[sourceArray.Length];

        for (int i = 0; i < newArray.Length; i++)
        {
            if (i == newIndex) newArray[i] = sourceArray[oldIndexOfElement];
            else newArray[i] = sourceArray[i];
        }

        return newArray;
    }
}
