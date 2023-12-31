using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class particlePlay : MonoBehaviour
{
    [SerializeField] private ParticleSystem healParticle = default;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("itemGood"))
        {
            healParticle.Play();
        }
    }
}
