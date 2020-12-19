using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StompDetection : MonoBehaviour
{
    [SerializeField]
    private int durability = 1;

    [SerializeField]
    public UnityEvent onStomp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.GetComponent<IBreakable>() != null)
        {
            durability--;
            if (durability <= 0)
            {
                onStomp?.Invoke();
            }
        }
    }
}
