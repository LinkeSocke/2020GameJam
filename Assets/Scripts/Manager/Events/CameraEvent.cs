using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvent : MonoBehaviour, IGameEvent
{
    private GameObject cameraRouteController;

    public void Initialize(GameObject cameraRouteController)
    {
        this.cameraRouteController = cameraRouteController;
        cameraRouteController.SetActive(false);
    }

    public void Invoke()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        player.GetComponentInChildren<Camera>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;

        cameraRouteController.SetActive(true);
        cameraRouteController.GetComponent<CameraController>().StartCameraRoute();
    }
}
