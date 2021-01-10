using System.Collections.Generic;
using UnityEngine;

public class SortManager : MonoBehaviour
{
    public int cloneCount = 100;
    GameObject bar;
    List<int> lengthList;
    int index;

    public struct Barobj
    {
        public int height { get; }
        public Bar script { get; }
        public Barobj(int h, Bar s) { height = h; script = s;}
    }

    public Barobj[] barArray;

    private void Start()
    {
        Camera.main.transform.position = new Vector3((cloneCount + 1) / 2, cloneCount / 2, -cloneCount);
        bar = Resources.Load("Bar") as GameObject;
        init();
    }

    public void init()
    {
        barArray = new Barobj[cloneCount];
        lengthList = new List<int>();
        for (int i = 0; i < cloneCount; i++)
        {
            lengthList.Add(i + 1);
        }

        for (int i = 0; i < cloneCount; i++)
        {
            var obj = Instantiate(bar, new Vector3(i, 0, 0), new Quaternion(), transform);
            index = Random.Range(0, lengthList.Count);
            obj.transform.localScale = new Vector3(1, lengthList[index], 1);
            barArray[i] = new Barobj(lengthList[index], obj.GetComponent<Bar>());
            lengthList.RemoveAt(index);
        }
    }
}
