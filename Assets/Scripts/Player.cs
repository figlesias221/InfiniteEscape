using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    private void Update()
    {
        speed = SpeedValues.PlayerSpeed;
    }
}
