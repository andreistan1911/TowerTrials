using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public string type;

    [Tooltip("NavMesh Waypoints")]
    public Waypoint[] waypoints = { };

    private NavMeshAgent agent;
    private int currentWaypoint = 0;

    private EnemyStats stats;

    private void Start()
    {
        // Setup stats
        stats = new(Global.enemyValues[type]);

        // Setup NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
            Debug.LogError("Null agent");
        if (waypoints.Length == 0)
            Debug.LogError("Waypoints must not be an empty Array!");

        agent.speed = stats.speed;
    }

    private void Update()
    {
        // Follow NavMesh route
        FollowRoute();

        Debug.Log(name + " " + stats.health);
    }

    public void TakeDamage(float damage)
    {
        // TODO: elemental here?
        stats.health -= damage;

        if (stats.health <= 0)
        {
            // TODO: death animation
            Destroy(gameObject);
        }
    }

    private void FollowRoute()
    {
        agent.SetDestination(waypoints[currentWaypoint].transform.position);

        float distance = Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position);

        if (distance < 0.7)
        {
            if (currentWaypoint >= waypoints.Length - 1)
            {
                currentWaypoint = -1;
            }

            currentWaypoint++;
        }
    }
}
