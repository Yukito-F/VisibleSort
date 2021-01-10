using System.Collections;
using UnityEngine;

public class ShellSort : SortManager
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine("shellSort", barArray);
    }

    IEnumerator shellSort(Barobj[] array)
    {
        int increment, j;
        Barobj temp;

        increment = 4;
        while (increment > 0)
        {
            for (int i = 0; i < array.Length; i++)
            {
                j = i;
                temp = array[i];
                while ((j >= increment) && (array[j - increment].haight > temp.haight))
                {
                    array[j] = array[j - increment];
                    array[j].script.reflesh(j - increment);
                    j -= increment;
                    yield return null;
                }
                array[j] = temp;
                array[j].script.reflesh(j - increment);
                yield return null;
            }
            if (increment / 2 != 0)
                increment /= 2;
            else if (increment == 1)
                increment = 0;
            else
                increment = 1;
        }
    }
}