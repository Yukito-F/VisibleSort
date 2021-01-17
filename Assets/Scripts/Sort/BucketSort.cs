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
        Barobj[] buckets = new Barobj[range];

        for (int i = 0; i < range; i++)
        {
            buckets[i] = new Barobj(0, null);
        }

        for (int i = 0; i < array.Length; i++)
        {
            buckets[array[i].height] = array[i];
        }

        int j = 0;
        for (int i = 0; i < range; i++)
        {
            if (0 < buckets[i].height)
            {
                //array[j].script.refresh(array[j].height);
                array[j] = buckets[i];
                array[j].script.refresh(i);
                j++;
                yield return null;
            }
        }
    }
}
