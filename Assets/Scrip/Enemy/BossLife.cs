using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using System;
using static Unity.Collections.AllocatorManager;
using Unity.VisualScripting;

public class BossLife : MonoBehaviour
{
    public static BossLife instance;
    private Rigidbody2D rb;
    private Animator animator;
    private GameObject _myOject;
    public Transform player;
    [SerializeField] private GameObject broc1;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject victoryItem;

    [Header("Audio")]
    [SerializeField] private AudioManagerGamePlay AudioSFX;

    [Header("DashSystem")]
    Vector2 movedirection;
    [SerializeField] private TrailRenderer trailRender;

    [Header("BossData")]  
    [SerializeField] private Slider healthBbar;
    [SerializeField] private TextMeshProUGUI valueText;
    public int currentHP;
    public int MaxHP;
    [SerializeField] private int TakeDamege;
    [SerializeField] private SpriteRenderer _spriteRender;
    [SerializeField] private ParticleSystem healParticle1,healParticle2,victoryParticle;
    [SerializeField] private float movespeed;
    private int dem = 1;
    private bool okheal;
    
    private void Awake()
    {

        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        trailRender = GameObject.FindGameObjectWithTag("Enemy").GetComponent<TrailRenderer>();
        _spriteRender = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        inIt();
        newGame();
    }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        victoryPanel.SetActive(false);
    }
    private void inIt()
    {

        if (trailRender == null)
        {
            return;
        }
        if (player == null)
        {
            return;
        }

        healthBbar.maxValue = MaxHP;
        healthBbar.value = currentHP;
        valueText.text = currentHP.ToString() + " / " + MaxHP.ToString();
        victoryItem.SetActive(false);
    }
    private void Update()
    {
        inIt();
        FinalStageBoos();
    }

    private void CheckStageBoss2()
    {
        if (this.currentHP >= 40 && this.currentHP <= 50)
        {
            dem++;
            if (dem == 2)
            {
                dem++;
                MaxHP += 200;
                currentHP = MaxHP;
                AudioSFX.BuffHeal_1();
                healParticle1.Play();
                healParticle2.Play();
            }
            if (dem != 2)
            {
               
                this.currentHP = currentHP;
            }
        }
    }
    private void FinalStageBoos() 
    {
        CheckStageBoss2();
        CheckStageBoss1(); 
    }
 
    private void CheckStageBoss1()
    {      
        if (this.currentHP > 0 && this.currentHP <= 30)
        {

            StartCoroutine(Dieing());
        }       
    }

    private void BossRun()
    {     
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, movespeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

    private void newGame()  
    {
        resetHP();
    }
    private void resetHP()
    {
        this.MaxHP = this.currentHP;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            currentHP += TakeDamege;       
        }
        if(currentHP <= 0)
        {
            victoryItem.SetActive(true);
            animator.SetBool("Death", true);
            onDeath(5);        
        }
        
    }
    public void destroyGameObject()
    {
        Destroy(gameObject);
        TrailRenderer train = trailRender;
        if(train == null)
        {
            return;
        }
    }
    public IEnumerator Dieing()
    {
        broc1.SetActive(true);
        yield return new WaitForSeconds(1);       
        rb.gravityScale = 0;
        trailRender.emitting = true;
        BossRun();           
        _spriteRender.color = Color.red;
        

    }
   
   
    public void onDeath(float time)
    {
        
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetBool("Death", true);
        _spriteRender
            .DOFade(0f, time)
            .OnComplete(() =>
            {
                
                Destroy(this.gameObject);               
                Destroy(this.trailRender);
                Destroy(this.broc1);
                AudioSFX.VictorySFX();
                victoryParticle.Play();
                victoryPanel.SetActive(true);
            })
            .Play()
            ;
    }

}

