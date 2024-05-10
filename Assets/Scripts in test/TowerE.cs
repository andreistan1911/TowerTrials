using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerE : Tower
{
    override public void Fire(Enemy enemy)
    {
        enemy.TakeDamage(damage, element);
    }
}
