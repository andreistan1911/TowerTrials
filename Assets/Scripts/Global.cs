using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Dictionary<string, EnemyStats> enemyValues = new();
    public static Dictionary<string, ReactionStats> reactionValues = new();

    public enum StatusEffect
    {
        None,
        Fire,
        Water,
        Nature
    }
}
