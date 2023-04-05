using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rigidBody2D;

    void Start()
    {
        player = GetComponentInChildren<Player>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        player.direction = new Vector2(0, directionY).normalized;
    }

    void FixedUpdate()
    {
        transform.position += player.direction * player.speed * Time.deltaTime;
    }
}
