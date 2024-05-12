using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TowerA : Tower
{
    [Tooltip("Projectiles speed")]
    public float projectileSpeed;
    [Tooltip("Prefab of the projectile that is shot")]
    public GameObject projectilePrefab;

    private Transform _fireRoot;
    private float _lastFire;

    private new void Start()
    {
        base.Start();

        _fireRoot = transform.Find("FireRoot");
        _lastFire = 0;

        Assert.IsNotNull(_fireRoot);
        Assert.IsNotNull(projectilePrefab);
        Assert.AreNotEqual(0, projectileSpeed);
    }

    public void Fire(GameObject target)
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, _fireRoot.position, Quaternion.identity);
        Projectile projectile = projectileInstance.GetComponent<Projectile>();

        if (projectile == null)
        {
            Destroy(projectileInstance);
            Debug.LogError("Projectile script not found on the projectile prefab.");
            return;
        }

        projectile.Target = target.transform;
        projectile.Damage = damage;
        projectile.Speed = projectileSpeed;
        projectile.Element = element;
    }

    override public void Fire(Enemy enemy)
    {
        if (Time.time - _lastFire >= attackRate)
        {
            Fire(enemy.transform.Find("ShootRoot").gameObject);
            _lastFire = Time.time;
        }
    }
}
