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

    private Transform fireRoot;
    private float lastFire;

    private new void Start()
    {
        base.Start();

        fireRoot = transform.Find("FireRoot");
        lastFire = 0;

        Assert.IsNotNull(fireRoot);
        Assert.IsNotNull(projectilePrefab);
        Assert.AreNotEqual(0, projectileSpeed);
    }

    public void Fire(GameObject target)
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, fireRoot.position, Quaternion.identity);
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
    }

    override public void Fire(Enemy enemy)
    {
        if (Time.time - lastFire >= attackRate)
        {
            Fire(enemy.gameObject);
            lastFire = Time.time;
        }
    }
}
