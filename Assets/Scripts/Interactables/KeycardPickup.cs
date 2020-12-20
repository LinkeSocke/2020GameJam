using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class KeycardPickup : MonoBehaviour
{
    [SerializeField] private Keycard keycard = null;

    private void Start()
    {
        var sprite = GetComponent<SpriteRenderer>();
        sprite.color = keycard.keycardColor;
        sprite.sprite = keycard.keycardSprite;
    }

    public void Pickup()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        var playerController = player.GetComponent<PlayerController>();
        if (playerController == null) return;

        playerController.AddKeycard(keycard);

        Destroy(this.gameObject);
    }

}
