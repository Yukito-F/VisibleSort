using System.Collections;
using UnityEngine;

public class InsertSort : SortManager
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine("insertSort", barArray);
    }

    IEnumerator insertSort(Barobj[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            for (int j = i; j >= 1 && array[j - 1].height > array[j].height; --j)
            {
                (array[j], array[j - 1]) = (array[j - 1], array[j]);
                array[j].script.refresh(j);
                array[j - 1].script.refresh(j - 1);
                playSound(array[j].height);
                yield return null;
            }
            //yield return null;
        }
        nowPlaying = false;
    }
}