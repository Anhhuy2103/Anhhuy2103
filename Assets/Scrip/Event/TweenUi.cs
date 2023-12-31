using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TweenUi : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private Button _button;
    [SerializeField] private Ease _easetype;

    private Sequence _enterSequence;
    private void Awake()
    {
        var scale = _button.transform.DOScale(Vector3.one * 1.2f, 0.5f);
        var color = _button.image.DOColor(Color.magenta,0.3f);
        

        _enterSequence = DOTween.Sequence();
        _enterSequence
            .Append(scale)
            .Join(color)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(_easetype)
            .SetAutoKill(true)
            .OnPause(() =>
            {
                _button.transform.localScale = Vector3.one;
            });
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _enterSequence.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _enterSequence.Pause();
    }
}
