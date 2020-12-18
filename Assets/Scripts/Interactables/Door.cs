using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform entranceDoor = null;
    [SerializeField] private Transform exitDoor = null;
    [SerializeField] private bool checkForObject = false;
    [SerializeField] private EKeycardType checkType = EKeycardType.BLUE;



    public void ActivateDoor()
    {
        if (checkForObject)
        {
            
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
