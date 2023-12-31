using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    
    private Animator animator;
    private Rigidbody2D rb;
    private GameObject _myOject;


    [SerializeField] private GameObject menudeath;
    
    [Header("PlayerData")]
    public int currentHp;
    public int maxHp = 20;
    
    [SerializeField] private TextMeshProUGUI valueText;
   
    [SerializeField] private Slider HealthBar;
    [SerializeField] private GameObject _powerRing;
    [SerializeField] private SpriteRenderer _spriteRender;

    [Header("DameValue")]
    [SerializeField] private int TakeDamege;

    private void Awake()
    {
      
        inIt();
        NewGame();
        animator = GetComponentInChildren<Animator>();
       
        rb = GetComponent<Rigidbody2D>();
    }
    private void inIt()
    {
        HealthBar.maxValue = maxHp;
        HealthBar.value = currentHp;
        valueText.text = currentHp.ToString() + " / " + maxHp.ToString();
        
    }
    private void Update()
    {
        inIt();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("enemyBullet")) && currentHp > 0)
        {
            currentHp += TakeDamege;
            animator.SetTrigger("Hurt");
        }
        if (collision.collider.CompareTag("Enemy") && currentHp > 0)
        {
            animator.SetTrigger("Hurt");
            StartCoroutine(getHurt());
        }
        if(currentHp <=0)
        {
            animator.SetBool("Death", true);
           
        }       
    }

   
    public void onDeath(float time)
    {
        animator.SetBool("Death", true);
        rb.bodyType = RigidbodyType2D.Static;
        _spriteRender
            .DOFade(0f, time)
            .OnComplete(() =>
            {
                Destroy(this.gameObject);
                Openmenu();
            })
            .SetAutoKill(true)
            .Play()
            ;
    }

    public void Openmenu()
    {       
        Time.timeScale = 0f;
        menudeath.SetActive(true);      
    }
    public void OnClickRestartYes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    private void NewGame()
    {
        resetHP();
        _powerRing.SetActive(true);
        StartCoroutine(DelayPowerRing());
    }
    
    IEnumerator DelayPowerRing()
    {
        yield return new WaitForSeconds(1);
        _powerRing.SetActive(false);
    }
    private void resetHP()
    {
        this.maxHp = this.currentHp;
    }
    private IEnumerator getHurt()
    {

        Physics2D.IgnoreLayerCollision(8, 9); 
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(8, 9,false);

    }
}

