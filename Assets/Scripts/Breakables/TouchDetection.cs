using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class TouchDetection : MonoBehaviour
{
    [SerializeField]
    public UnityEvent onTouch;

    private bool isChecking = false;

    private void Awake()
    {
        StartCoroutine(DoWaitForDetection(2.0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isChecking)
        {

            if((collision.gameObject.tag == "Player" || collision.gameObject.layer == 8 ))
            {
                onTouch?.Invoke();
            }
        }
    }

    public IEnumerator DoWaitForDetection(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isChecking = true;

    }
}
