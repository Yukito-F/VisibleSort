using UnityEngine;

public class Bar : MonoBehaviour
{
    public void reflesh(int target)
    {
        Vector3 tempVector = transform.position;
        tempVector.x = target;
        transform.position = tempVector;
        colorShift();
        Invoke("colorShift", 0.05f);
    }

    void colorShift()
    {
        if (gameObject.GetComponent<Renderer>().material.color == Color.white)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
