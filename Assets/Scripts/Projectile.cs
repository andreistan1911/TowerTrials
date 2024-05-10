using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Projectile : MonoBehaviour
{
    private Global.Element _element;

    private float _damage;
    private float _speed;

    private Transform _target;
    private Vector3 _direction;
    private readonly float _birthTime;

    public Transform Target {
        set { _target = value; }
    }

    public float Damage {
        set { _damage = value; }
    }

    public float Speed
    {
        set { _speed = value; }
    }

    public Global.Element Element
    {
        set { _element = value; }
    }

    private void Update()
    {
        MoveToTarget();

        if (_target == null)
        {
            Destroy(gameObject);
        }
    }

    private void MoveToTarget()
    {
        if (_target == null)
            return;

        _direction = (_target.position - transform.position).normalized;
        transform.position += _speed * _direction * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            enemy.TakeDamage(_damage, _element);
            Destroy(gameObject);
        }
    }
}
