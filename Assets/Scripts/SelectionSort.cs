using System.Collections;
using UnityEngine;

public class SelectionSort : SortManager
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine("selectionSort", barArray);
    }

    IEnumerator selectionSort(Barobj[] array)
    {
        int min;

        for (int i = 0; i < array.Length - 1; i++)
        {
            min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j].height < array[min].height)
                {
                    min = j;
                }
            }
                
            (array[i], array[min]) = (array[min], array[i]);
            array[i].script.reflesh(i);
            array[min].script.reflesh(min);
            yield return null;
        }

    }
}
