using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;



public class WipeDoTween : MonoBehaviour
{
    [SerializeField] private Transform _mywipe;
    [SerializeField] private Ease _earseType;
    private Sequence _sequence;
    
        
    private void Update()
    {

        if(Input.anyKey)
        {
            doWipeRight();
        }

    }
    
    private void doWipeRight()
    {
        var moveRight = _mywipe.DOMove(new Vector2(-1200,_mywipe.position.y), 0.5f).OnComplete(() =>
        {
            Debug.Log("Banner Move");
        });
       
        _sequence = DOTween.Sequence();
        _sequence
            .Append(moveRight)
            .SetLoops(1)
            .SetEase(_earseType)
            .SetAutoKill(false)
            .OnPause(() =>
            {
                _mywipe.transform.localScale = Vector3.one;
            })
            .Play();
    }
   
}
