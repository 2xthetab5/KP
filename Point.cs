using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Enemy enemy;

    private Spawner spawner;

   private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        Instantiate(enemy, transform.position, transform.rotation);
        enemy.health = Mathf.RoundToInt(spawner.enemyHealth);
        enemy.damage = Mathf.RoundToInt(spawner.enemyDamage);
    }
}
