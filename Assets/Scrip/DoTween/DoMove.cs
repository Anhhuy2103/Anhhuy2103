using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static UnityEditor.Progress;


public class DoMove : MonoBehaviour
{
    [SerializeField] private Ease _easetype;
    [SerializeField] private Transform _myBannerMove;

    private Sequence _Sequence;


    private void Start()
    {
        doMove();
    }

    private void doMove()
    {
        var position = _myBannerMove.transform.DOScale(Vector3.one * 2.5f, 0.25f).OnComplete(() =>
        {
            Debug.Log("Banner Move");
        });
        _Sequence = DOTween.Sequence();
        _Sequence
            .Append(position)

            .SetLoops(1)
            .SetEase(_easetype)
            .SetAutoKill(true)
            .OnPause(() =>
            {
                _myBannerMove.transform.localScale = Vector3.one;
            })

            .Play();

    }
}
// if(turnRateCOunt >= turnRate){
// dosomething();
// _turnRateCount = defautle;}
//else{
//_turnRateCOunt*time.Deltatime;