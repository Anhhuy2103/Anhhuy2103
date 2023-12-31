using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using TMPro;


public class LoadingGame : MonoBehaviour
{
    public static LoadingGame Instance;
    [Header("Menu Scene")]
    [SerializeField] private GameObject loadingscene;
    [SerializeField] private GameObject ccc;
    [SerializeField] private Button button;
    [SerializeField] private TMPro.TMP_Text text;
    

    [Header("Slider")]
    [SerializeField] private Slider loadingSlide;
    [SerializeField]
    private float target;
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
        button.gameObject.SetActive(false);
        ccc.gameObject.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            button.gameObject.SetActive(true);
            ccc.gameObject.SetActive(true);
            text.text = ("Click to Open Fun");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            button.gameObject.SetActive(false);
            ccc.gameObject.SetActive(false);
           
        }
    }
    public async void LoadScene(string sceneName)
    {
        
        loadingSlide.value = 0;
        target = 0;
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;      
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
        
    }
}
