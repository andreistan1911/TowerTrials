using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Projectile : MonoBehaviour
{

    private float damage;
    private float speed;


    private Transform target;
    private Vector3 direction;
    private readonly float birthTime;

    public Transform Target {
        set { target = value; }
    }

    public float Damage {
        set { damage = value; }
    }

    public float Speed
    {
        set { speed = value; }
    }

    private void Update()
    {
        MoveToTarget();

        if (target == null)
        {
            Destroy(gameObject);
        }
    }

    private void MoveToTarget()
    {
        if (target == null)
            return;

        direction = (target.position - transform.position).normalized;
        transform.position += speed * direction * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
