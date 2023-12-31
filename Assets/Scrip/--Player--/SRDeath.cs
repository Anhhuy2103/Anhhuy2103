using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SRDeath : MonoBehaviour
{
    public PlayerLife playerlife;
    private void Start()
    {
       playerlife = GetComponentInParent<PlayerLife>();
    }
    public void ONdeath()
    {
        playerlife.onDeath(2);   
    }
}
