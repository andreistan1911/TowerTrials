using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected Transform _target;
    protected float _damage;
    protected Global.Element _element;
    protected float _speed;

    protected Vector3 _direction;

    public Transform Target
    {
        set { _target = value; }
    }

    public float Damage
    {
        set { _damage = value; }
    }

    public Global.Element Element
    {
        set { _element = value; }
    }

    public float Speed
    {
        set { _speed = value; }
    }
}
