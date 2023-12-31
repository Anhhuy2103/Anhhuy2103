using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NhapNhay : MonoBehaviour
{
    private Vector3 basesScale;
    private Vector3 ScaleTo;
    [SerializeField] private Ease _easetype;
    [SerializeField] private Transform  _myBannerMove;
    private Sequence _Sequence;
    private Sequence _Sequence2;
   

    private void Start()
    {
        basesScale = transform.localScale;
        ScaleTo = basesScale * 1.2f;
        onScale();
        doMove();
    }
    private void onScale()
    {
        var Scale = transform.DOScale(ScaleTo, 1.0f);
        _Sequence2 = DOTween.Sequence();
        _Sequence2
            .Append(Scale)
            .SetEase(_easetype)
            .SetLoops(-1, LoopType.Yoyo)
            .OnComplete(() =>
            {
                transform.DOScale(basesScale, 1.0f)
                .SetEase(Ease.InBounce)
                .SetDelay(0.3f)
                .OnComplete(onScale)
                .SetAutoKill(false)
                .Play();
            });
    }
    private void doMove()
    {
        var move = _myBannerMove.DOMove(new Vector2(_myBannerMove.position.x, 100), 2f).OnComplete(() =>
        {
            Debug.Log("Button Move");
        });
        var Scale = transform.DOScale(ScaleTo, 1.0f);
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