using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BulletExpo : MonoBehaviour
{  
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Animator _bulletAnimator;
    [SerializeField] private Rigidbody2D mybody;

    
    

    private void Awake()
    {      
        _bulletAnimator =  GetComponent<Animator>();
        
    }
    private void Start()
    {
        
        mybody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         
        if (collision.CompareTag("Enemy") || collision.CompareTag("itemGood"))
        {
           
            _bulletAnimator.SetTrigger("Explo");
            removeForce();
            Destroy(gameObject,5f);
            
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("itemGood"))
        {

            _bulletAnimator.SetTrigger("Explo");
            removeForce();
            Destroy(gameObject,5f);

        }
    }
    
    public void removeForce()
    {
        mybody.velocity = new Vector2(0, 0);
    }


}
