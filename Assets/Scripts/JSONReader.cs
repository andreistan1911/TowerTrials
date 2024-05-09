using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset textJSON;

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

    public EnemyParsedList enemyParsedList = new();

    private void Awake()
    {
        ReadEnemy();
    }

    private void ReadEnemy()
    {
        enemyParsedList = JsonUtility.FromJson<EnemyParsedList>(textJSON.text);

        for (int i = 0; i < enemyParsedList.enemy.Length; ++i)
        {
            EnemyParsed currentEnemy = enemyParsedList.enemy[i];
            EnemyStats enemyStats = new(currentEnemy.health, currentEnemy.speed);

            Global.enemyValues.Add(currentEnemy.type, enemyStats);
        }
    }
}
