using System.Collections;
using UnityEngine;

public class SelectSort : SortManager
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine("selectSort", barArray);
    }

    IEnumerator selectSort(Barobj[] array)
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
                array[j].script.refresh(j);
                yield return null;
            }

            (array[i], array[min]) = (array[min], array[i]);
            array[i].script.refresh(i);
            array[min].script.refresh(min);
            yield return null;
        }

    }
}
