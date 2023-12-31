using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControler : MonoBehaviour
{
    [SerializeField] private float Bulletspeed;
    private Rigidbody2D myBody;

    private void Awake()
    {
            myBody = GetComponent<Rigidbody2D>();
            onFire();
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void onFire()
    {
        if(transform.localRotation.z > 0)
        {
            myBody.AddForce(new Vector2(-1, 0) * Bulletspeed, ForceMode2D.Impulse);
        }
        else
        {
            myBody.AddForce(new Vector2(1, 0) * Bulletspeed, ForceMode2D.Impulse);
        }
        
    }

  
    public void removeForce()
    {
        myBody.velocity = new Vector2(0, 0);
    }
}
