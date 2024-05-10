using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset enemyJSON;
    public TextAsset reactionJSON;

    [System.Serializable]
    public class EnemyParsed
    {
        public string type;
        public float health;
        public float speed;
    }

    [System.Serializable]
    public class EnemyParsedList
    {
        public EnemyParsed[] enemy;
    }

    [System.Serializable]
    public class ReactionParsed
    {
        public string name;
        public string displayName;
        public float damage;
        public float slowValue; // Must be in [0, 1]
        public float slowDuration;
        public string buff; // must be handled
    }

    [System.Serializable]
    public class ReactionParsedList
    {
        public ReactionParsed[] reaction;
    }

    public EnemyParsedList enemyParsedList = new();
    public ReactionParsedList reactionParsedList = new();

    private void Awake()
    {
        ReadEnemies();
        ReadReactions();
    }

    private void ReadEnemies()
    {
        enemyParsedList = JsonUtility.FromJson<EnemyParsedList>(enemyJSON.text);

        for (int i = 0; i < enemyParsedList.enemy.Length; ++i)
        {
            EnemyParsed currentEnemy = enemyParsedList.enemy[i];
            EnemyStats enemyStats = new(currentEnemy.health, currentEnemy.speed);

            Global.enemyValues.Add(currentEnemy.type, enemyStats);
        }
    }

    private void ReadReactions()
    {
        reactionParsedList = JsonUtility.FromJson<ReactionParsedList>(reactionJSON.text);

        for (int i = 0; i < reactionParsedList.reaction.Length; ++i)
        {
            ReactionParsed currentReaction = reactionParsedList.reaction[i];
            ReactionStats reactionStats = new(currentReaction.displayName, currentReaction.damage, currentReaction.slowValue, currentReaction.slowDuration, currentReaction.buff);

            Global.reactionValues.Add(currentReaction.name, reactionStats);
        }
    }
}

