using System;
using UnityEngine;

public class MovigPad : MonoBehaviour
{
    private Transform pointA;
    private Transform pointB;
    private bool checkPoint = false;
    
    public float speed;
    private void Update()
    {
        if (checkPoint)
        {
            transform.position = Vector3.Lerp(pointA.position, pointB.position, speed * Time.deltaTime);
            checkPoint = false;
        }
        else if (!checkPoint)
        {
            transform.position = Vector3.Lerp(pointB.position, pointA.position, speed * Time.deltaTime);
            checkPoint = true;
        }
    }
}
