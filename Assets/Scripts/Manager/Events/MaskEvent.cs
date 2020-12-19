using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskEvent : MonoBehaviour, IGameEvent
{
    public void Invoke()
    {
        var maskList = GameObject.FindObjectsOfType<SpriteMask>();
    }
}
