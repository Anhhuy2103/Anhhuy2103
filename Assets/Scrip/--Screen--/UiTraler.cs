using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{   
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject text;
    private void Awake()
    {
        mainMenu.SetActive(false);        
    }
    private void Update()
    {        
        if (Input.anyKey)
        {
            mainMenu.SetActive(true);
            text.SetActive(false);          
        }
    }
}
