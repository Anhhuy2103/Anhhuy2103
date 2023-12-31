using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crossfade : MonoBehaviour
{
    [SerializeField] Animator _myTransitonAni;
    
    private int dem;
    private int check()
    {
        var click = Input.anyKey;
        if (click)
        {
            dem++;
        }
        return dem;
    }
    private void Update()
    {
        if (Input.anyKey)
        {           
            _myTransitonAni.SetTrigger("Start");
            
        }       
    }
}
