using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float movementSpeed;

    int waypointIndex = 0;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, movementSpeed * Time.deltaTime);

        float distance = (transform.position - waypoints[waypointIndex].transform.position).magnitude;

        if (distance < 0.001f)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
        {
            GameManager.instance.health.LoseHealth();
            Destroy(transform.gameObject);
        }
    }    

    void Update()
    {
        Move();
    }
}
