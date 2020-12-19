using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteract;

    private void Awake()
    {
        if (OnInteract == null)
            OnInteract = new UnityEvent();
    }

    public void Interact()
    {
        OnInteract.Invoke();
    }
}
