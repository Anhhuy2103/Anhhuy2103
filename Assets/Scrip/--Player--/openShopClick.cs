using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class openShopClick : MonoBehaviour
{
    
    public PlayerLife playerHp;
    public ScoreScrip playerScore;
    public GameObject shopMenuPanel;
    private void Start()
    {
        this.shopMenuPanel.SetActive(false);
    }
    private void Update()
    {
        openShopMenu();
    }
    public void openShopMenu()
    {
        if(playerHp.currentHp <= 10)
        {
            this.shopMenuPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void closeShopMenu()
    {
        this.shopMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        return;
    }
    public void onClicltobuy() 
    {
        if(playerScore.scoreNum >= 5)
        {
            this.playerHp.currentHp += 5;
            this.playerScore.scoreNum -= 10;
            playerScore.scoreText.text = "Banana x " + playerScore.scoreNum.ToString();
            this.shopMenuPanel.SetActive(false) ;
            Time.timeScale = 1f;
        }
        else
        {
            this.shopMenuPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
