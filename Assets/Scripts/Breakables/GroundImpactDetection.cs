using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundImpactDetection : MonoBehaviour
{
    [SerializeField]
    public UnityEvent onImpact;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 8 || collision.gameObject.GetComponent<IBreakable>() != null)
    //    {
    //        onImpact?.Invoke();
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log($"Collision with {collision.gameObject.name} with tag {collision.gameObject.tag}");
        if (collision.gameObject.layer == 8 || collision.gameObject.GetComponent<IBreakable>() != null)
        {
            onImpact?.Invoke();
        }
    }

}
