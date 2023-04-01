using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player = GetComponentInChildren<Player>();
    }

    // Update is called once per frame
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
