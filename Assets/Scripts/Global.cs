using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Dictionary<string, EnemyStats> enemyValues = new();
    public static Dictionary<Element, Dictionary<Element, ReactionStats>> reactionValues = new();

    public static float inflictStatusDuration = 1.0f;

    public enum Element
    {
        None,
        Fire,
        Lightning,
        Nature,
        Poison,
        Water
    }
}
