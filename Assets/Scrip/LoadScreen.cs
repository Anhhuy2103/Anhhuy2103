using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] private Button myButton;
    [SerializeField] private string sceneNames;
    private const string MainLevelSceneName = "Home";
    
    public void OnClickMyButton()
    {
        //SceneManager.LoadScene(MainLevelSceneIndex);
        SceneManager.LoadScene(MainLevelSceneName);
        Time.timeScale = 1f;
    }

    public void OnClickMyButtons(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

}
