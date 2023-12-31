using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetDelay : MonoBehaviour
{
    public GameObject item1,item2,item3;
    public GameObject healitem1;

    private void Start()
    {
        StartCoroutine(Spawndelay());
    }
    private IEnumerator Spawndelay()
    {
        yield return new WaitForSeconds(30);
        item1.SetActive(true);
    }
    private IEnumerator SpawnUpTrap1()
    {
        yield return new WaitForSeconds(20);
        item2.SetActive(true);
    }
    private IEnumerator SpawnUpTrap2()
    {
        yield return new WaitForSeconds(35);
        item3.SetActive(true);
    }
    private IEnumerator SpawHealitem1()
    {
        yield return new WaitForSeconds(35);
        healitem1.SetActive(true);
    }
}
