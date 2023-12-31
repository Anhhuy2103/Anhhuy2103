using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEditor;
using System;


public class LoadingDelay : MonoBehaviour
{
    public static LoadingDelay Instance;
    [Header("Menu Scene")]
    [SerializeField] private GameObject loadingscene;
    [SerializeField] private GameObject mainMenu;

    [Header("Slider")]
    [SerializeField] private Slider loadingSlide;
    [SerializeField] private Text text;
    private float target;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    public async void LoadScene(string sceneName)
    {
        text.text = 0f + "%";
        loadingSlide.value = 0;
        target = 0;
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;
        mainMenu.SetActive(false);
        loadingscene.SetActive(true);

        do
        {
            await Task.Delay(100);
            target = scene.progress;
            
        } while (scene.progress < 0.9f);
            await Task.Delay(1000);   
            scene.allowSceneActivation = true;
            loadingscene.SetActive(false);
            
    }

    private void Update()
    {
        loadingSlide.value = Mathf.MoveTowards(loadingSlide.value, target, 3 * Time.deltaTime);
        text.text = loadingSlide.value * 100f + "%";
    }
}
