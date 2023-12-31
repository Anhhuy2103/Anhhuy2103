using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScrip : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scoreNum;

    private void Start()
    {
        scoreNum = 10;
        scoreText.text = "Banana x " + scoreNum.ToString();
    }
    private void Update()
    {
       DontDestroyOnLoad(scoreText.gameObject);
      
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "VictoryItem")
        {
            scoreNum += 10;
            Destroy(collision.gameObject);
            scoreText.text = "Banana x  " + scoreNum.ToString();
        }
    }
}
