using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aciveBroc : MonoBehaviour
{
    BossLife boss;
    public GameObject broc;
    private void Start()
    {
        boss = GetComponent<BossLife>();
    }
    private void Update()
    {
        
        if(boss.currentHP <= 0)
        {
            this.broc.SetActive(true);
        }
        StartCoroutine(activeDelay());
    }
    IEnumerator activeDelay()
    {
        if (this.broc.activeSelf)
        {
            yield return new WaitForSeconds(1);
            this.broc.SetActive(false);
        }
    }
}
