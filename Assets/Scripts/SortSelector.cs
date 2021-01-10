using UnityEngine;
using UnityEngine.UI;

public class SortSelector : MonoBehaviour
{
    public short pointer = 0;
    public GameObject[] sortList;
    GameObject obj;
    Text text;

    private void Start()
    {
        text = this.GetComponent<Text>();
    }
    private void Update()
    {
        if (!obj)
        {
            text.text = sortList[pointer].name;
            if (Input.GetKeyDown(KeyCode.UpArrow)) if (pointer < sortList.Length - 1) pointer++;
            if (Input.GetKeyDown(KeyCode.DownArrow)) if (pointer > 0) pointer--;
            if (Input.GetKeyDown(KeyCode.Space)) obj = Instantiate(sortList[pointer]);
        }
        else
        {
            text.text = "";
            if (Input.GetKeyUp(KeyCode.R)) Destroy(obj);
        }
    }
}
