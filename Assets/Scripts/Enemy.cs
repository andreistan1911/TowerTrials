using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public string type;
    public Global.Element status;

    [Tooltip("NavMesh Waypoints")]
    public Waypoint[] waypoints = { };

    private NavMeshAgent _agent;
    private int _currentWaypoint = 0;

    private EnemyStats _stats;
    

    private void Start()
    {
        // Setup stats
        _stats = new(Global.enemyValues[type]);

        // Setup NavMeshAgent
        _agent = GetComponent<NavMeshAgent>();

        if (_agent == null)
            Debug.LogError("Null agent");
        if (waypoints.Length == 0)
            Debug.LogError("Waypoints must not be an empty Array!");

        _agent.speed = _stats.speed;
    }

    private void Update()
    {
        // Follow NavMesh route
        FollowRoute();
    }

    public void TakeDamage(float damage, Global.Element element)
    {
        HandleReaction(element);
        HandleDamage(damage);
    }

    private void HandleReaction(Global.Element element)
    {
        //TODO

        print(Global.reactionValues[Global.Element.Fire][Global.Element.Nature].displayName);
        print(Global.reactionValues[Global.Element.Fire][Global.Element.Water].damage);
    }

    private void HandleDamage(float damage)
    {
        _stats.health -= damage;

        if (_stats.health <= 0)
        {
            // TODO: death animation
            Destroy(gameObject);
        }
    }

    private void FollowRoute()
    {
        _agent.SetDestination(waypoints[_currentWaypoint].transform.position);

        float distance = Vector3.Distance(waypoints[_currentWaypoint].transform.position, transform.position);

        if (distance < 0.7)
        {
            if (_currentWaypoint >= waypoints.Length - 1)
            {
                _currentWaypoint = -1;
            }

            _currentWaypoint++;
        }
    }
}
