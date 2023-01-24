using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject variantBoss;

    public float bossHealth;
    public float increaseHealth;
    public float bossDamage;
    public float increaseDamage;

    private ScoreManager smBoss;

    void Update()
    {
        //if (smBoss.score <= 15)
        //{
        //    Instantiate(variantBoss, transform.position, Quaternion.identity);
        //}
    }
}
