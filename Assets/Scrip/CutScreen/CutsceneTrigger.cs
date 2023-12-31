using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private string triggername;
    

    public static event Action <string> CutsceneEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CutsceneEvent?.Invoke(triggername);
            Destroy(gameObject);
        }
    }
}
