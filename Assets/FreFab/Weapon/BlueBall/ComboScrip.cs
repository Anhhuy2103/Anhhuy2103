using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboScrip : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scoreNum;
    void Start()
    {
        scoreNum = 0;
        scoreText.text = "Combo x " + scoreNum.ToString();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag==("Bullet"))
        {
            scoreNum+=1;
            scoreText.text = "Combo x " + scoreNum.ToString();  
        }

    }
}
