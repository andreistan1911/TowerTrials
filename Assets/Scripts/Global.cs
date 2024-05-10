using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Dictionary<string, EnemyStats> enemyValues = new();
    public static Dictionary<Element, Dictionary<Element, ReactionStats>> reactionValues = new();

    public enum Element
    {
        None,
        Fire,
        Water,
        Nature
    }
}
