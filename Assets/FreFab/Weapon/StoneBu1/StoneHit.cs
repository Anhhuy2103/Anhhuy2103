using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHit : MonoBehaviour
{
    [SerializeField] private GameObject stone;   
    [SerializeField] private Rigidbody2D mybody;
    private void Awake()
    {
      
    }
    private void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Player"))
        {                     
            Destroy(gameObject,3f);

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Player"))
        {
                   
            Destroy(gameObject, 3f);

        }
    }
    public void removeForce()
    {
        mybody.velocity = new Vector2(0, 0);
    }

}
