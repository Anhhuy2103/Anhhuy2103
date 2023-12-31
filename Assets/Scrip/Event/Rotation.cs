using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Rotation : MonoBehaviour
{
     [SerializeField] private Vector3 rotation;
    [SerializeField] private Ease _myease;
    [SerializeField] private LoopType _myLoopType;
    private void Awake()
    {
        //transform.DORotate(new Vector3(180f, 180f, 180f), 0.5f, RotateMode.FastBeyond360)
        //     .SetLoops(-1, _myLoopType)
        //     .SetRelative()
        //     .SetEase(_myease);

        transform.DOMove(new Vector3(0.0f, 0.0f, 5.0f), 5.0f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(_myease);

    }
    private void Update()
    {
      transform.Rotate(rotation,0.5f);
    }
}
