using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealBootItem : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioManagerGamePlay AudioSFX;
    [Header("BlahBlah")]
    public Collider2D itemCollider;
    public Rigidbody2D rb;
    PlayerLife playerHealth;
    public int HP = 50;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = FindObjectOfType<PlayerLife>();
    } 
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (playerHealth.currentHp < playerHealth.maxHp)
            {
                Destroy(gameObject);
                AudioSFX.BuffHeal_1();
                playerHealth.currentHp += HP;
            }
            else
            {
                AudioSFX.BuffHeal_1();
                Destroy(gameObject);
                playerHealth.currentHp = playerHealth.maxHp;
            }
        }       
    }
   

    public void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.CompareTag("Bullet"))
        {
            this.itemCollider.isTrigger = false;
            this.rb.gravityScale = 1.0f;
        }

        if (collision.CompareTag("Enemy")) 
        { 
            this.itemCollider.isTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            this.itemCollider.isTrigger = false;            
        }
        if (collision.CompareTag("Enemy")) 
        { 
            this.itemCollider.isTrigger = true; 
        }

    }
}
