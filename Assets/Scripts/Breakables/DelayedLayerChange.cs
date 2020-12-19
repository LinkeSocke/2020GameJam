using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedLayerChange : MonoBehaviour
{
    [SerializeField]
    private float delayAmount = 1.5f;

    [SerializeField]
    private int targetLayer;

    [SerializeField]
    private bool startOnEnable = true;

    private float cdEndTime = 0.0f;

    private void OnEnable()
    {
        if(startOnEnable)
        {
            StartCoroutine(waitForLayerChange(delayAmount));
        }
    }

    private void Start()
    {
        if(!startOnEnable)
        {
            StartCoroutine(waitForLayerChange(delayAmount));
        }
    }


    private IEnumerator waitForLayerChange(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        ChangeLayer();
        
    }

    private void ChangeLayer()
    {
        gameObject.layer = targetLayer;
    }
}
