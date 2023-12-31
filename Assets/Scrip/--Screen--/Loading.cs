using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [Header("Menu Scene")]
    [SerializeField] private GameObject loadingscene;
    [SerializeField] private GameObject mainMenu;

    [Header("Slider")]
    [SerializeField] private Slider loadingSlide;
    [SerializeField] private Text text;

    public void loadlevelScene(string sceneName)
    {
        mainMenu.SetActive(false);
        loadingscene.SetActive(true);
        StartCoroutine(LoadAsync(sceneName));
    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone) 
        {
            float ProgressValue = Mathf.Clamp01(operation.progress/0.9f);
            loadingSlide.value = ProgressValue;           
            text.text = ProgressValue * 100f + "%";
            operation.allowSceneActivation = false;
            if (operation.progress >= 0.9f)
            {
                loadingSlide.value = loadingSlide.maxValue;
                text.text = "Press any button to continue";
                text.color = Color.white;
                if (Input.anyKeyDown)
                    operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    //public void loadingScrene(int sceneIndex)
    //{
    //    StartCoroutine(LoadAsync(sceneIndex));
    //}
    //IEnumerator LoadAsync(int sceneIndex)
    //{
    //    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    //    loadingscene.SetActive(true);
    //    operation.allowSceneActivation = false;
    //    while (!operation.isDone)
    //    {
    //        float progress = Mathf.Clamp01(operation.progress / .9f);
    //        loadingSlide.value = progress;
    //        text.text = progress * 100f + "%";
    //        if (operation.progress >= 0.9f)
    //        {
    //            loadingSlide.value = loadingSlide.maxValue;
    //            text.text = "Press any button to continue";
    //            if (Input.anyKeyDown)
    //                operation.allowSceneActivation = true;
    //        }
    //        yield return null;
    //    }
    }
