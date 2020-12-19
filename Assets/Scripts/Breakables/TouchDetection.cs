using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class TouchDetection : MonoBehaviour
{
    [SerializeField]
    public UnityEvent onTouch;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Player" || collision.gameObject.GetComponent<IBreakable>() != null))
        {
            onTouch?.Invoke();
        }
    }
}
