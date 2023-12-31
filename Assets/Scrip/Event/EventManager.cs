using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class EventManager : MonoBehaviour
{
    public static event Action changePosition;
    public static event Action takeSprite;
    public void Update()
    {
        changePosition?.Invoke();

    }
}
