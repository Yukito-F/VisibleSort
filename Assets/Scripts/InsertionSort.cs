using System.Collections;
using UnityEngine;

public class InsertionSort : SortManager
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine("insertionSort", barArray);
    }

    IEnumerator insertionSort(Barobj[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            for (int j = i; j >= 1 && array[j - 1].height > array[j].height; --j)
            {
                (array[j], array[j - 1]) = (array[j - 1], array[j]);
                array[j].script.reflesh(j);
                array[j - 1].script.reflesh(j - 1);
                yield return null;
            }
            //yield return null;
        }
    }
}