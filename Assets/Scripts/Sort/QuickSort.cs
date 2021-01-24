using System.Collections;
using UnityEngine;

public class QuickSort : SortManager
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(quickSort(barArray));
    }

    IEnumerator quickSort(Barobj[] array)
    {
        yield return sort(array, 0, array.Length - 1);
    }

    IEnumerator sort(Barobj[] array, int left, int right)
    {
        int i = left;
        int j = right;

        int pivot = array[(left + right) / 2].height;

        while (true) {
            while (array[i].height < pivot) i++;
            while (pivot < array[j].height) j--;
            if (i >= j) break;
            (array[i], array[j]) = (array[j], array[i]);
            array[i].script.refresh(i);
            array[j].script.refresh(j);
            yield return null;
            i++;
            j--;
        }

        if (left < i - 1) yield return sort(array, left, i - 1);
        if (j + 1 < right) yield return sort(array, j + 1, right);
    }
}
