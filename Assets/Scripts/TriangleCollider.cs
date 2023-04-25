using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleCollider : MonoBehaviour
{
    public Vector2 vertex1;
    public Vector2 vertex2;
    public Vector2 vertex3;

    public void SetVertices(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3)
    {
        this.vertex1 = vertex1;
        this.vertex2 = vertex2;
        this.vertex3 = vertex3;
    }

    public bool CheckCollision(Vector2 circlePos, float circleRadius)
    {
        Vector2 centerPos = transform.position;
        float distance1 = Vector2.Distance(circlePos, centerPos + vertex1);
        float distance2 = Vector2.Distance(circlePos, centerPos + vertex2);
        float distance3 = Vector2.Distance(circlePos, centerPos + vertex3);
        Debug.Log(distance1 + " " + distance2 + " " + distance3);
        return distance1 <= circleRadius || distance2 <= circleRadius || distance3 <= circleRadius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 p1 = transform.position + new Vector3(vertex1.x, vertex1.y, 0);
        Vector3 p2 = transform.position + new Vector3(vertex2.x, vertex2.y, 0);
        Vector3 p3 = transform.position + new Vector3(vertex3.x, vertex3.y, 0);
        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p2, p3);
        Gizmos.DrawLine(p3, p1);
    }

    // Helper function to find the closest point on the triangle to a given point
    private Vector2 ClosestPointOnTriangle(Vector2 point)
    {
        // Find the closest point on each edge of the triangle
        Vector2 closestPoint1 = ClosestPointOnLine(vertex1, vertex2, point);
        Vector2 closestPoint2 = ClosestPointOnLine(vertex2, vertex3, point);
        Vector2 closestPoint3 = ClosestPointOnLine(vertex3, vertex1, point);

        // Check which of the closest points is actually closest to the given point
        float distance1 = Vector2.Distance(closestPoint1, point);
        float distance2 = Vector2.Distance(closestPoint2, point);
        float distance3 = Vector2.Distance(closestPoint3, point);

        if (distance1 <= distance2 && distance1 <= distance3)
        {
            return closestPoint1;
        }
        else if (distance2 <= distance1 && distance2 <= distance3)
        {
            return closestPoint2;
        }
        else
        {
            return closestPoint3;
        }
    }

    // Helper function to find the closest point on a line segment to a given point
    private Vector2 ClosestPointOnLine(Vector2 start, Vector2 end, Vector2 point)
    {
        Vector2 line = end - start;
        float t = Mathf.Clamp01(Vector2.Dot(point - start, line) / Vector2.Dot(line, line));
        return start + t * line;
    }
}
