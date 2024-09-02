using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTask1 : MonoBehaviour
{

    [SerializeField] private bool isMoving = true;
    [SerializeField] private float speed = 1f;
    [SerializeField] private List<Vector3> points;

    private bool isForward = true;
    private int nextPointIndex = 0;

    private void FindNextPoint()
    {
        if (isForward)
        {

            if (nextPointIndex < points.Count - 1)
            {
                nextPointIndex++;
            }
            else
            {
                isForward = false;
                nextPointIndex--;
            }
        }
        else
        {
            if (nextPointIndex > 0)
            {
                nextPointIndex--;
            }
            else
            {
                isForward = true;
                nextPointIndex++;
            }
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[nextPointIndex], Time.deltaTime * speed);
            if (transform.position == points[nextPointIndex])
            {
                FindNextPoint();
            }    
            
            transform.Rotate(Vector3.up, 1);
        }
    }
}
