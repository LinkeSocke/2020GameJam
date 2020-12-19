using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererMasking : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer renderer = default;
    public void EnableMasking()
    {
        renderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    public void DisableMasking()
    {
        renderer.maskInteraction = SpriteMaskInteraction.None;
    }
}
