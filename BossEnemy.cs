using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    private float timeBtwAttack_2;
    //private static float rotationY = 0;
    //private float rotationSpeed = 5f;

    private ScoreManager smBoss;
    private Player player_2;
    private Animator anim_2;

    private void Start()
    {
        anim_2 = GetComponent<Animator>();
        player_2 = FindObjectOfType<Player>();
        normalSpeed = speed;
        smBoss = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            smBoss.BossKill();
            Destroy(gameObject);
        }
        LookAt();
        GoTo();
    }
    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        health -= damage;
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack_2 <= 0)
            {
                anim_2.SetTrigger("enemyAttack");
            }
            else
            {
                timeBtwAttack_2 -= Time.deltaTime;
            }
        }
    }

    public override void OnEnemyAttack()
    {
        //Instantiate(deathEffect, player.transform.position, Quaternion.identity);
        player_2.health -= damage;
        timeBtwAttack_2 = startTimeBtwAttack;
    }
}
