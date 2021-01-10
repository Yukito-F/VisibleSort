using System.Collections.Generic;
using UnityEngine;

public class SortManager : MonoBehaviour
{
    public int cloneCount = 100;
    GameObject bar;
    List<int> lenghtList;
    int index;

    public struct Barobj
    {
        public int haight { get; }
        public Bar script { get; }
        public Barobj(int h, Bar s) { haight = h; script = s;}
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
        lenghtList = new List<int>();
        for (int i = 0; i < cloneCount; i++)
        {
            lenghtList.Add(i + 1);
        }

        for (int i = 0; i < cloneCount; i++)
        {
            var obj = Instantiate(bar, new Vector3(i, 0, 0), new Quaternion(), transform);
            index = Random.Range(0, lenghtList.Count);
            obj.transform.localScale = new Vector3(1, lenghtList[index], 1);
            barArray[i] = new Barobj(lenghtList[index], obj.GetComponent<Bar>());
            lenghtList.RemoveAt(index);
        }
    }
}
