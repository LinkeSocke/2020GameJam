using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskEvent : MonoBehaviour, IGameEvent
{
    public void Invoke()
    {
        var spriteRenderers = GameObject.FindObjectsOfType<SpriteRenderer>();
        foreach(var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
        }
    }
}
