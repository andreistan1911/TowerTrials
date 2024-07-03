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
    private Dictionary<int, int> _nrShotsBuffed;

    public void Start()
    {
        _nrShotsBuffed.Add(Global.BUFF_NONE, 0);
        _nrShotsBuffed.Add(Global.BUFF_SLOW, 0);
        _nrShotsBuffed.Add(Global.BUFF_SHRED, 0);

        Assert.AreNotEqual(0, attackRate);
    }

    public void Buff(int buffCode)
    {
        _buffCode &= buffCode;
    }

    private void SetNrOfShotsToBeBuffed()
    {
        // TODO: Maybe we change 3 as something else
        if (_buffCode == Global.BUFF_NONE)
        {
            _nrShotsBuffed[Global.BUFF_SLOW] = 0;
            _nrShotsBuffed[Global.BUFF_SHRED] = 0;
        }
        else
            _nrShotsBuffed[_buffCode] = 3;
    }

    private void DoBuffLogic()
    {
        if (_buffCode == Global.BUFF_NONE)
            return;

        if (_buffCode == Global.BUFF_SLOW)
        {

        }
    }

    public void Fire(Enemy enemy)
    {
        SetNrOfShotsToBeBuffed();

        DoFireLogic(enemy);
        UpdateBuffState();
    }

    private void UpdateBuffState()
    {
        if (_nrShotsBuffed[Global.BUFF_SLOW] > 0)
            _nrShotsBuffed[Global.BUFF_SLOW]--;
        else
            _buffCode ^= Global.BUFF_SLOW;

        if (_nrShotsBuffed[Global.BUFF_SHRED] > 0)
            _nrShotsBuffed[Global.BUFF_SHRED]--;
        else
            _buffCode ^= Global.BUFF_SHRED;
    }

    abstract public void DoFireLogic(Enemy enemy);
}
