using System.Collections;
using UnityEngine;

public class HeapSort : SortManager
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine("heapSort", barArray);
    }

    IEnumerator heapSort(Barobj[] array)
    {
        for (int heapEnd = array.Length - 1; heapEnd > 0; heapEnd--)
        {
            for (int root = heapEnd / 2 - 1; root >= 0; root--)
            {
                int leaf = 2 * root + 1;//left leaf

                if (leaf < heapEnd && array[leaf].haight < array[leaf + 1].haight)
                {
                    leaf++;
                }

                if (array[root].haight < array[leaf].haight)
                {
                    (array[root], array[leaf]) = (array[leaf], array[root]);
                    array[root].script.reflesh(root);
                    array[leaf].script.reflesh(leaf);
                    yield return null;
                }
            }

            (array[0], array[heapEnd]) = (array[heapEnd], array[0]);
            array[0].script.reflesh(0);
            array[heapEnd].script.reflesh(heapEnd);
            yield return null;
        }
    }
}
