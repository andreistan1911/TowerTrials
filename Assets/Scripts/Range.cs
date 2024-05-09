using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Range : MonoBehaviour
{
    private Tower tower;
    private Dictionary<Enemy, float> enemies; // <enemy object, time spent in range>

    private void Start()
    {
        tower = transform.parent.GetComponent<Tower>();
        enemies = new Dictionary<Enemy, float>();

        // Just to be sure
        if (tower == null)
        {
            Debug.Log("Error: tower not found from range");
        }
    }

    private void Update()
    {
        foreach (var enemy in enemies.Keys.ToList())
        {
            enemies[enemy] += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // It should be enemy to add in dictionary
        if (!other.CompareTag("Enemy"))
            return;

        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        enemies.Add(enemy, 0);
        tower.Fire(enemy);
    }

    private void OnTriggerStay(Collider other)
    {
        // It should be enemy to shoot
        if (!other.CompareTag("Enemy"))
            return;

        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        
        if (enemies[enemy] >= tower.attackRate)
        {
            enemies[enemy] = 0;
            tower.Fire(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // It should be enemy to remove from dictionary
        if (!other.CompareTag("Enemy"))
            return;

        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        enemies[enemy] = 0;
        enemies.Remove(enemy);
    }
}
