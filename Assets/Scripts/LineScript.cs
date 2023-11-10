using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    List<Vector3> points;
    void SetPoint(Vector3 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }
    public void UpdateLine(Vector3 position)
    {
        if (points == null)
        {
            points = new List<Vector3>();
            SetPoint(position);
        }
        if (Vector3.Distance(position, points.Last()) > 0.005f){
            SetPoint(position);
        }
    }
}
