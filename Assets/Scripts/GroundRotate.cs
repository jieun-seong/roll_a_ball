using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotate : MonoBehaviour
{
    private int count = 40;
    private int change = -10;

    void Update()
    {
        if (count == 80)
        {
            change *= -1;
            count = 0;
        }
        else
        {
            count++;
        }
        transform.Rotate(new Vector3(change,20,change) * Time.deltaTime);
    }
}
