using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutsceneDirector;

    private void Awake()
    {
        CutsceneTrigger.CutsceneEvent += OncutsceneEvent;
    }

    private void OnDestroy()
    {
        CutsceneTrigger.CutsceneEvent -= OncutsceneEvent;
    }

    private void OncutsceneEvent(string triggername)
    {
        cutsceneDirector.Play();
    }
}
