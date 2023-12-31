using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StopPause : MonoBehaviour
{
 
    public GameObject MenuGame;
    public static bool isPause = false;
    void Start()
    {
        MenuGame.SetActive(false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        { 
            if(isPause)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void pauseGame()
    {
        MenuGame.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void resumeGame()
    {
        MenuGame.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;

    }
}
