using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{

    public Vector2 basescale;
    public static FlipSprite instance;
    public SpriteRenderer theSprite;
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        theSprite = GameObject.FindGameObjectWithTag("Enemy").GetComponent<SpriteRenderer>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameObject.FindGameObjectWithTag("Enemy")) 
        { return; }
        
        if(collision.CompareTag ("Weapon"))
        {
            theSprite.flipX = true;
           
        }     
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!GameObject.FindGameObjectWithTag("Enemy"))
        { return; }
        if (collision.CompareTag("Weapon"))
        {
            theSprite.flipX = false;
          
        }
    }
}
