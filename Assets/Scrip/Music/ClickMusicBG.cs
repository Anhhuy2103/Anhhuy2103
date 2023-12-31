using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMusicBG : MonoBehaviour
{
    [SerializeField] private AudioSource clickAudioBg;
    [SerializeField] private AudioSource BGAudio;
    

    private void Update()
    {
        onClickmusic();
    }
    private void onClickmusic()
    {
        if (Input.anyKey)
        {
            BGAudio.Pause();
            clickAudioBg.Play();
        }
    }
}
