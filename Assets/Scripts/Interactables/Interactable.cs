using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private bool displayTooltip = false;
    [SerializeField] private Sprite interactButtonSprite = null;
    [SerializeField] private Material interactButtonMaterial = null;
    [SerializeField] private float interactSpriteOffset = 10f;
    [SerializeField] private int interactButtonLayer = 10;
    [SerializeField] private float playerDetectionRange = 0f;
    public UnityEvent OnInteract;

    private GameObject player;
    private bool inRange = false;
    private GameObject interactSpriteObj = null;

    private void Awake()
    {
        if (OnInteract == null)
            OnInteract = new UnityEvent();

        if (!displayTooltip) return;

        player = GameObject.FindGameObjectWithTag("Player");

        interactSpriteObj = new GameObject($"InteractSprite_{gameObject.name}");
        interactSpriteObj.transform.SetParent(this.gameObject.transform);
        var interactSpritePos = new Vector3(transform.position.x, transform.position.y + interactSpriteOffset, 10);
        interactSpriteObj.transform.position = interactSpritePos;
        var spriteRenderer = interactSpriteObj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        spriteRenderer.sprite = interactButtonSprite;
        spriteRenderer.material = interactButtonMaterial;
        spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
        spriteRenderer.sortingOrder = interactButtonLayer;

        interactSpriteObj.SetActive(false);
    }

    public void Interact()
    {
        OnInteract.Invoke();
    }

    private void Update()
    {
        if (!displayTooltip) return;

        if (Vector3.Distance(this.transform.position, player.transform.position) > playerDetectionRange)
        {
            inRange = false;
        }
        else inRange = true;

        interactSpriteObj.SetActive(inRange);

    }
}
