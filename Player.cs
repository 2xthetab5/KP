using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private float moveInput_2;
    public float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite RedHeart;
    public Sprite YellowHeart;

    private Rigidbody2D rb;
    private Animator anim;
    public bool facingRight = true;

    public GameObject panel;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = RedHeart;
            }
            else
            {
                hearts[i].sprite = YellowHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        moveInput = Input.GetAxis("Horizontal");
        moveInput_2 = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveInput * speed, moveInput_2 * speed);

        if (moveInput == 0)
        {
            anim.SetBool("Move", false);
        }
        else
        {
            anim.SetBool("Move", true);
        }
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        if (health <= 0)
        {
            panel.SetActive(true);
            Destroy(gameObject);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
