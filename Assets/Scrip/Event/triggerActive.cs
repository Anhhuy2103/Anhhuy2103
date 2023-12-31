using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class trigger : MonoBehaviour
{
    [SerializeField] private Ease _myease;
    public static trigger Instance;
    private Sequence sequence;
    [SerializeField] private GameObject healitem;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    private void Start()
    {
        healitem.gameObject.SetActive(false);           
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            healitem.gameObject.SetActive(true);     
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startHealhealitem();
        }
    }
    private void startHealhealitem()
    {
        StartCoroutine(DelayHealth());
    }
    private IEnumerator DelayHealth()
    {
        yield return new WaitForSeconds(3);
        healitem.gameObject.SetActive(false);
    }
}
