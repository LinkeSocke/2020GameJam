using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundImpactDetection : MonoBehaviour
{
    [SerializeField]
    public UnityEvent onImpact;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onImpact?.Invoke();
        }
    }
}
