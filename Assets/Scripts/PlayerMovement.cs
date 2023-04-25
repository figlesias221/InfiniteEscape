using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    public CircleCollider playerCollider;
    void Start()
    {
        player = GetComponentInChildren<Player>();
    }

    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        player.direction = new Vector2(0, directionY).normalized;

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in obstacles)
        {
            if (obstacle != null) {
                CircleCollider obstacleCollider = obstacle.GetComponent<CircleCollider>();
                if (obstacleCollider && obstacleCollider.CheckCollision(transform.position, playerCollider.radius))
                {
                    Destroy(player.gameObject);
                }
                TriangleCollider t = obstacle.GetComponent<TriangleCollider>();
                if (t && t.CheckCollision(transform.position, playerCollider.radius))
                {
                    Debug.Log("Triangle collision");
                    Destroy(player.gameObject);
                }
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;
        currentPosition += player.direction * player.speed * Time.deltaTime;
        currentPosition.y = Mathf.Clamp(currentPosition.y, -4.5f, 4.4f);
        transform.position = currentPosition;
    }
}
