using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform exitDoor = null;
    [SerializeField] private bool checkForObject = false;
    [SerializeField] private EKeycardType checkType = EKeycardType.BLUE;

    public void ActivateDoor()
    {
        if (checkForObject)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) return;

            var keycards = player.GetComponent<PlayerController>().GetKeycards();
            if (keycards == null || keycards.Count <= 0) return;

            foreach(Keycard card in keycards)
            {
                if(card.keycardType == checkType)
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
}
