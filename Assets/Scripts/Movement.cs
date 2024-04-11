using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] points;

    private int currentPoint;
    public float speed;

    void FixedUpdate()
    {
        PointsMovement();
    }

    private void Start()
    {
        if (points.Length > 0)
        {
            transform.position = points[0].position;
            currentPoint = 0;
        }
        else
        {
            Debug.LogError("points minimun 1");
        }
    }

    private void PointsMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, speed);
        if (transform.position == points[currentPoint].position)
        {
            currentPoint++;
            if (points.Length == currentPoint)
            {
                currentPoint = 0;
            }
        }
    }
}