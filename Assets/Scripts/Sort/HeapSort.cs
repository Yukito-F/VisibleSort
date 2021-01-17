using System.Collections;
using UnityEngine;

public class HeapSort : SortManager
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(heapSort(barArray));
    }

    IEnumerator heapSort(Barobj[] array)
    {
        int heapEnd = array.Length - 1;
        for (int root = heapEnd / 2 - 1; root >= 0; --root)
        {
            yield return downHeap(array, root, heapEnd);
        }


        while (heapEnd >= 1)
        {
            (array[0], array[heapEnd]) = (array[heapEnd], array[0]);
            array[0].script.refresh(0);
            array[heapEnd].script.refresh(heapEnd);

            heapEnd--;

            yield return downHeap(array, 0, heapEnd);
        }
    }

    IEnumerator downHeap(Barobj[] array, int root, int heapEnd)
    {
        while (root * 2 < heapEnd)
        {
            int leaf = 2 * root + 1;//left leaf

            if (leaf < heapEnd && array[leaf].height < array[leaf + 1].height)
            {
                leaf++;
            }

            if (array[root].height < array[leaf].height)
            {
                (array[root], array[leaf]) = (array[leaf], array[root]);
                array[root].script.refresh(root);
                array[leaf].script.refresh(leaf);
                root = leaf;
                yield return null;
            }
            else
            {
                break;
            }
        }
    }

}
