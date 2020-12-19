using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform exitDoor = null;

    [SerializeField] private bool randomizeDoor = false;
    [SerializeField] private bool checkForKeycard = false;

    [SerializeField] private Keycard keycard = null;
    [SerializeField] private KeycardCollection keycardCollection = null;

    private void Start()
    {
        if (randomizeDoor && exitDoor != null)
        {
            int rand = Mathf.RoundToInt(Random.Range(0f, (float)keycardCollection.keycards.Count - 1));
            keycard = keycardCollection.keycards[rand];

            if(exitDoor.GetComponentInParent<Door>() != null)
            {
                exitDoor.GetComponentInParent<Door>().SetKeycard(keycard);
            }
        }

        if(checkForKeycard && keycard != null)
        {
            SetKeycard(keycard);
        }
    }

    public void SetKeycard(Keycard keycard)
    {
        this.keycard = keycard;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = keycard.doorSprite;
        spriteRenderer.color = keycard.keycardColor;
    }

    public void ActivateDoor()
    {
        if (checkForKeycard && keycard != null)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) return;

            var keycards = player.GetComponent<PlayerController>().GetKeycards();
            if (keycards == null || keycards.Count <= 0) return;

            foreach(Keycard card in keycards)
            {
                if(card.keycardType == keycard.keycardType)
                {
                    activate();
                }
            }
        }
        else
        {
            activate();
        }
    }

    private void activate()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        player.transform.position = exitDoor.position;
    }

    private void OnValidate()
    {
        if (randomizeDoor) checkForKeycard = true;
    }
}
