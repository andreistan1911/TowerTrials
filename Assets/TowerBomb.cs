using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TowerBomb : Tower
{
    [SerializeField]
    private float launchHeight;

    [SerializeField]
    private GameObject bombPrefab;

    private Transform _fireRoot;
    private float _lastFire;

    private new void Start()
    {
        base.Start();

        _fireRoot = transform.Find("FireRoot");
        _lastFire = 0;

        Assert.IsNotNull(_fireRoot);
        Assert.IsNotNull(bombPrefab);
        Assert.AreNotEqual(0, launchHeight);
    }

    private void Fire(GameObject target)
    {
        GameObject bulletInstance = Instantiate(bombPrefab, _fireRoot.position, Quaternion.identity);
        Bomb bomb = bulletInstance.GetComponent<Bomb>();

        if (bomb == null)
        {
            Destroy(bulletInstance);
            Debug.LogError("Bullet script not found on the projectile prefab.");
            return;
        }

        bomb.Target = target.transform;
        bomb.Damage = damage;
        bomb.Element = element;

        //bomb.Height = launchHeight;
    }

    override public void Fire(Enemy enemy)
    {
        
    }
}
