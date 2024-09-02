using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MovementTask2 : MonoBehaviour
{

    [SerializeField] private float speed = 2f;
    [SerializeField] private List<Transform> points;
    [SerializeField] private Transform torch;
    private int currentPointIndex = 0;
    private int nextPointIndex = 1;
    private float passDistance = 0.2f;

    private void FindNextPoint()
    {
        currentPointIndex = nextPointIndex;

        if (nextPointIndex < points.Count - 1)
        {
            nextPointIndex++;
        }
        else
        {
            nextPointIndex = 0;
        }
        
    }

    private void Start()
    {
        currentPointIndex = 0;
        nextPointIndex = 1;
        torch.SetParent(points[currentPointIndex]);
    }

    private void Update()
    {
        points[currentPointIndex].position = Vector3.MoveTowards(points[currentPointIndex].position,
            points[nextPointIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(points[currentPointIndex].position, points[nextPointIndex].position) <= passDistance)
        {
            FindNextPoint();
            points[currentPointIndex].LookAt(points[nextPointIndex].position);
            torch.SetParent(points[currentPointIndex]);
            torch.LookAt(points[nextPointIndex].position);

        }
    }
}
