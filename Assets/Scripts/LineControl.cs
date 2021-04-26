using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class LineControl : MonoBehaviour
{
    // Private variables.
    
    private LineRenderer _lr;

    void Awake()
    {
        _lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        _lr.positionCount = 2;

        Vector3[] points = new Vector3[2];

        points[0] = startPoint;

        points[1] = endPoint;

        _lr.SetPositions(points);

    }


    public void EndLine()
    {
        _lr.positionCount = 0;

    }

}
