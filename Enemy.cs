using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MobMotor
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int health;
    public float speed;
    public GameObject deathEffect;
    public int damage;
    public float stopTime;
    public float startStopTime;
    public float normalSpeed;
    private Player player;
    private Animator anim;
    private static float rotationY = 0;
    private float rotationSpeed = 5f;
    private ScoreManager sm;


    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        normalSpeed = speed;
        sm = FindObjectOfType<ScoreManager>();
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
            sm.Kill();
            Destroy(gameObject);
        }
        LookAt();
        GoTo();
    }
    public override void LookAt()
    {
        if (player != null)
        {
            transform.localEulerAngles = Vector3.up * rotationY * rotationSpeed;
        }
    }

    public override void GoTo()
    {
        if (player != null)
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
            Vector3 dir = player.transform.position - gameObject.transform.position;
            gameObject.transform.position += dir.normalized * speed * Time.deltaTime;
        }
    }

    public void TakeDamage(int damage) 
    {
        stopTime = startStopTime;
        health -= damage;
    }

    virtual public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("enemyAttack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public override void OnEnemyAttack()
    {
        //Instantiate(deathEffect, player.transform.position, Quaternion.identity);
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }
}
