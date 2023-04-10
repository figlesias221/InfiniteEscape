using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacleOvertime : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 6);
    }
}
