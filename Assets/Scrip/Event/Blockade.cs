using UnityEngine;
using DG.Tweening;
using System;
public class Blockade : MonoBehaviour
{
    [SerializeField] private Vector3 endPosition;

    public static event Action StartRemovingBlockade;
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
        transform
            .DOMove(endPosition, 0.3f)
            .SetDelay(3f)
            .OnStart(() =>
            {
                StartRemovingBlockade?.Invoke();
            })
            .Play();
    }
}
