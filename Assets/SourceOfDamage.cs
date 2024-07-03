using UnityEngine;

public class SourceOfDamage : MonoBehaviour
{
    protected float _damage;
    protected Global.Element _element;

    public float Damage
    {
        set { _damage = value; }
    }

    public Global.Element Element
    {
        set { _element = value; }
    }
}