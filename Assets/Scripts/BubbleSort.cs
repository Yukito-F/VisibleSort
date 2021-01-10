using System.Collections;
using UnityEngine;

public class BubbleSort: SortManager
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine("bubbleSort", barArray);
    }

    IEnumerator bubbleSort(Barobj[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j].haight > array[j + 1].haight)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    array[j].script.reflesh(j);
                    array[j + 1].script.reflesh(j + 1);
                }
                yield return null;
            }
            //yield return null;
        }
    }
}
