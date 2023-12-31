using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Reflection;


public class NameBlink : MonoBehaviour
{

    [SerializeField] private Ease _easetype;
    [SerializeField] private Image _myBanner;
    [SerializeField] private Transform _myBannerMove;

    private Sequence _Sequence;

    private void Start()
    {
        Collorchange();
        doMove();
    }
   
    private void Collorchange()
    {
        var color2 = _myBanner.DOColor(Color.magenta, 0.9f);
        _Sequence = DOTween.Sequence();
        _Sequence
            .Append(color2)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(_easetype)
            .SetAutoKill(false)
            .OnPause(() =>
            {
                _myBanner.transform.localScale = Vector3.one;
            })
            .Play();
    }
       
    private void doMove()
    {
        DOTween.Kill(_myBannerMove);
        var move = _myBannerMove.DOMove(new Vector2(_myBannerMove.position.x, 700), 2f).OnComplete(() =>
        {
            Debug.Log("Banner Move");
        });
        _Sequence = DOTween.Sequence();
        _Sequence
            .Append(move)
            .SetLoops(1)
            .SetEase(_easetype)
            .SetAutoKill(false)
            .OnPause(() =>
            {
                _myBannerMove.transform.localScale = Vector3.one;
            })
             .Play();
    }
    
}
