using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundImpactDetection : MonoBehaviour
{
    [SerializeField]
    public UnityEvent onImpact;

    private bool isChecking = false;

    private void Awake()
    {
        StartCoroutine(DoWaitForDetection(.5f));
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 8 || collision.gameObject.GetComponent<IBreakable>() != null)
    //    {
    //        onImpact?.Invoke();
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isChecking)
        {
            if (collision.gameObject.layer == 8 || collision.gameObject.layer == 12 || collision.gameObject.GetComponent<IBreakable>() != null)
            {
                onImpact?.Invoke();
            }
        }
    }

    public IEnumerator DoWaitForDetection(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isChecking = true;

    }

}
