using System;
using UnityEngine;

public class MovingPad : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward;
    public float moveDistance;
    public float speed;

    private Vector3 startPoint;
    private Vector3 targetPoint;

    private void Start()
    {
        startPoint = transform.position;
        targetPoint = startPoint + moveDirection.normalized * moveDistance;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint) < 0.01f)
        {
            (startPoint, targetPoint) = (targetPoint, startPoint);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
}
