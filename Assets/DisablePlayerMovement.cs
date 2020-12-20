using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DisblePlayerMovement()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
    }
}
