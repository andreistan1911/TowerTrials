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
        if (status == element || (status == Global.Element.None && element != Global.Element.None))
        {
            // Reapply status or apply it if it had none.
            ApplyStatus(element);
            return;
        }

        if (status != Global.Element.None && element == Global.Element.None)
            return; // Nothing to do here
            
        // Status + Element Handler
        HandleDamage(Global.reactionValues[status][element].damage);
        ApplySlow(Global.reactionValues[status][element].slowValue, Global.reactionValues[status][element].slowDuration);

        switch (Global.reactionValues[status][element].displayName)
        {
            case "Pyrus Voltes":
                // TODO
                break;
            case "Terrus Pyrus":
                // TODO
                break;
            case "Pyrus Noxius":
                // TODO
                break;
            case "Pyrus Aquas":
                // Nothing
                print("Triggered Pyrus Aquas");
                break;
            case "Terrus Voltes":
                // TODO
                break;
            case "Noxius Voltes":
                // TODO
                break;
            case "Aquas Voltes":
                // TODO
                break;
            case "Terrus Aquas":
                // TODO
                break;
            case "Aquas Noxius":
                // TODO
                break;
            default:
                Debug.LogError("Undefined reaction!");
                print(status + " + " + element);
                break;
        }
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

    public void ApplySlow(float slowValue, float slowDuration)
    {
        StartCoroutine(ApplySlowRoutine(slowValue, slowDuration));
    }

    private void ApplyStatus(Global.Element element)
    {
        StartCoroutine(ApplyStatusRoutine(element));
    }

    private IEnumerator ApplyStatusRoutine(Global.Element element)
    {
        status = element;

        yield return new WaitForSeconds(Global.inflictStatusDuration);

        status = Global.Element.None;
    }

    private IEnumerator ApplySlowRoutine(float slowValue, float slowDuration)
    {
        _agent.speed = _stats.speed * (1 - slowValue);

        yield return new WaitForSeconds(slowDuration);

        _agent.speed = _stats.speed;
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
