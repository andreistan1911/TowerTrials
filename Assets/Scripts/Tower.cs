using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Tower : MonoBehaviour
{
    [Tooltip("Damage")]
    public float damage;
    [Tooltip("Seconds between shots")]
    public float attackRate;
    [Tooltip("Tower element")]
    public Global.Element element;

    protected int _buffCode = Global.BUFF_NONE;
    protected int _nrShotsBuffed = 0;

    public void Start()
    {
        Assert.AreNotEqual(0, attackRate);
    }

    public void Buff(int buffCode)
    {
        _buffCode = buffCode;
    }

    private void ApplyBuff()
    {
        // TODO: Maybe we change 3 as something else
        _nrShotsBuffed = _buffCode == Global.BUFF_NONE ? 0 : 3;
    }

    public void Fire(Enemy enemy)
    {
        ApplyBuff();
        DoFireLogic(enemy);
        UpdateBuffCode();
    }

    private void UpdateBuffCode()
    {
        if (_nrShotsBuffed > 0)
            _nrShotsBuffed--;
        else
            _buffCode = Global.BUFF_NONE;
    }

    abstract public void DoFireLogic(Enemy enemy);
}
