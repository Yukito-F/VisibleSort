using System.Collections;
using UnityEngine;

public class BucketSort : SortManager
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine("bucketSort", barArray);
    }

    IEnumerator bucketSort(Barobj[] array)
    {
        int range = cloneCount + 1;
        Barobj[] buckets = new Barobj[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            buckets[array.Length - array[i].height] = array[i];
            array[i].script.refresh(array.Length - array[i].height);
            yield return null;
        }

        int j = 0;
        for (int i = array.Length - 1; i >= 0 ; i--)
        {
            if (0 < buckets[i].height)
            {
                array[j] = buckets[i];
                for (int l = 0; l <= i; l++) buckets[l].script.refresh(l + array.Length - 1 - i);
                array[j].script.refresh(j);
                j++;
                yield return null;
            }
        }
    }
}
