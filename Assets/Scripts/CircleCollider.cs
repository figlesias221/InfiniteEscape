using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollider : MonoBehaviour
{
    public float radius;
    
    public bool CheckCollision(Vector2 circlePos, float circleRadius)
    {
        Vector2 centerPos = transform.position;
        float distance = Vector2.Distance(circlePos, centerPos);
        return distance <= radius + circleRadius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

