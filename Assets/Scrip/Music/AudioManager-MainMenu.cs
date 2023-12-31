
using UnityEngine;

public class AudioManagerMainMenu : MonoBehaviour
{
    [Header("----Audio----")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("---SFX---")]
    [SerializeField] private AudioClip BackGround_1;   
    [SerializeField] private AudioClip BackGround_2;
    [SerializeField] private AudioClip SFX_1;
    
    private void Start()
    {
        musicSource.clip = BackGround_1;
        musicSource.Play();
    }
    private void Update()
    {
        onClickMusic();
    }
    private void onClickMusic()
    {
        
        
        if (Input.anyKey)
        {
            SFXSource.clip = SFX_1;
            SFXSource.PlayOneShot(SFX_1);


        }
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
