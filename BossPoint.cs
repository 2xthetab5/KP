using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPoint : MonoBehaviour
{
    public BossEnemy boss;

    private BossSpawner bossspawner;

    private void Start()
    {
        bossspawner = FindObjectOfType<BossSpawner>();
        Instantiate(boss, transform.position, transform.rotation);
        boss.health = Mathf.RoundToInt(bossspawner.bossHealth);
        boss.damage = Mathf.RoundToInt(bossspawner.bossDamage);
    }
}
