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
        int heapEnd = array.Length - 1;
        for (int root = heapEnd / 2 - 1; root >= 0; --root)
        {
            int root_temp = root;
            while (root_temp * 2 + 1 <= heapEnd)
            {
                int leaf = 2 * root_temp + 1;//left leaf

                if (leaf < heapEnd && array[leaf].height < array[leaf + 1].height)
                {
                    leaf++;
                }

                if (array[root_temp].height < array[leaf].height)
                {
                    (array[root_temp], array[leaf]) = (array[leaf], array[root_temp]);
                    array[root_temp].script.reflesh(root_temp);
                    array[leaf].script.reflesh(leaf);
                    root_temp = leaf;
                    yield return null;
                }
                else
                {
                    break;
                }
            }
        }


        while (heapEnd >= 1)
        {
            (array[0], array[heapEnd]) = (array[heapEnd], array[0]);
            array[0].script.reflesh(0);
            array[heapEnd].script.reflesh(heapEnd);
            yield return null;

            heapEnd--;

            int root_temp = 0;
            while (root_temp * 2 < heapEnd)
            {
                int leaf = 2 * root_temp + 1;//left leaf

                if (leaf < heapEnd && array[leaf].height < array[leaf + 1].height)
                {
                    leaf++;
                }

                if (array[root_temp].height < array[leaf].height)
                {
                    (array[root_temp], array[leaf]) = (array[leaf], array[root_temp]);
                    array[root_temp].script.reflesh(root_temp);
                    array[leaf].script.reflesh(leaf);
                    root_temp = leaf;
                    yield return null;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
