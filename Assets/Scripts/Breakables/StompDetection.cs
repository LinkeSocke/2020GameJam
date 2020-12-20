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

    private bool isChecking = false;

    private void Awake()
    {
        StartCoroutine(DoWaitForDetection(2.0f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isChecking)
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

    public IEnumerator DoWaitForDetection(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isChecking = true;

    }
}
