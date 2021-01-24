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
                array[end - (i - center - 1)].script.refresh(i);
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
                    for (int l = j; l <= k; l++) temp[l].script.refresh(l + end - k);
                }
                array[i].script.refresh(i);
                yield return null;
            }


            //for (int i = first; i <= end; i++)
            //{
            //    temp[i] = array[i];
            //    array[i].script.refresh(i);
            //    yield return null;
            //}

            //int j = first, k = center + 1;
            //for (int i = first; i <= end; i++)
            //{
            //    if (j <= center && (k > end || temp[j].height <= temp[k].height) )
            //    {
            //        array[i] = temp[j];
            //        j++;
            //    }
            //    else
            //    {
            //        array[i] = temp[k];
            //        k++;
            //        for (int l = j; l <= center; l++) temp[l].script.refresh(l + j - first);
            //    }
            //    array[i].script.refresh(i);
            //    yield return null;
            //}
        }
    }
}
