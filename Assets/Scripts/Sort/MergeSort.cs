using System.Collections;
using UnityEngine;

public class MergeSort : SortManager
{
    Barobj[] temp;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(mergeSort(barArray));
    }

    IEnumerator mergeSort(Barobj[] array)
    {
        temp = new Barobj[array.Length];
        yield return sort(array, 0, array.Length - 1);
    }

    IEnumerator sort(Barobj[] array, int first, int end)
    {
        int center = Mathf.FloorToInt((first + end) / 2);
        if (first < end) 
        {
            yield return sort(array, first, center);// 左
            yield return sort(array, center + 1, end);// 右

            // 並べ替え
            for (int i = first; i <= center; i++)
            {
                temp[i] = array[i];
                array[i].script.refresh(i);
                yield return null;
            }

            for (int i = center + 1; i <= end; i++)
            {
                temp[end - (i - center - 1)] = array[i];
                array[i].script.refresh(end - (i - center - 1));
                yield return null;
            }

            int j = first, k = end;
            for (int i = first; i <= end; i++)
            {
                if (temp[j].height <= temp[k].height)
                {
                    array[i] = temp[j];
                    j++;
                }
                else
                {
                    array[i] = temp[k];
                    k--;
                }
                array[i].script.refresh(i);
                yield return null;
            }
        }
    }
}
