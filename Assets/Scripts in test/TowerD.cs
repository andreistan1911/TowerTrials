using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerD : Tower
{
    override public void DoFireLogic(Enemy enemy)
    {
        enemy.TakeDamage(damage, element, _buffCode);
    }
}
