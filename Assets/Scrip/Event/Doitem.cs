using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Doitem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject banner;
    [SerializeField] private GameObject text;
    
    [SerializeField] private Ease easetype;
    //[SerializeField] private Vector3 endposition;

    private Sequence _sequence;

 

    private void Awake()
    {      
        var scale = banner.transform.DOScale(Vector3.one * 1.5f, 1.25f);
        var textt = text.transform.DOScale(Vector3.one * 1.5f, 1.25f);
        


        _sequence = DOTween.Sequence();
        _sequence
            .Append(scale)
            .Join(textt)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(easetype)
            .SetAutoKill(false)
            .OnPause(() =>
            {
                banner.transform.localScale = Vector3.one;
            })
            .Play();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _sequence.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _sequence.Pause();
    }
}
