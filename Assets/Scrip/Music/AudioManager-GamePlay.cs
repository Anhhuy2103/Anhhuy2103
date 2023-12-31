
using UnityEngine;

public class AudioManagerGamePlay : MonoBehaviour
{
    [Header("----Audio----")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;

    [Header("---SFX---")]
    [SerializeField] public AudioClip BackGround_1;       
    [SerializeField] public  AudioClip SFX_1,SFXfire_1,SFXfire_2,SFXVic_1,SFXBuff;
    
    private void Start()
    {
        musicSource.clip = BackGround_1;
        musicSource.Play();
    }
    private void Update()
    {
       
    }
    private void onClickMusic()
    {
             
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlayEffect()
    {
        SFXSource.PlayOneShot(SFX_1);
    }
    public void EnemyFire()
    {
        SFXSource.PlayOneShot(SFXfire_2);
    }
    public void PlayerFire()
    {
        SFXSource.PlayOneShot(SFXfire_1);
    }
    public void VictorySFX()
    {
        SFXSource.PlayOneShot(SFXVic_1);
    }
    public void BuffHeal_1()
    {
        SFXSource.PlayOneShot(SFXBuff);
    }
}
