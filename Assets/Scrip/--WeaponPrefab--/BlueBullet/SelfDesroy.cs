using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelfDesroy : MonoBehaviour
{
    [SerializeField] private float aliveTime;
    private void Start()
    {
        selfDestroy();     
    }
    private void selfDestroy()
    {
        Destroy(gameObject, aliveTime);
    }
   
}
