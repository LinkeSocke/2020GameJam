using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightEvent : MonoBehaviour, IGameEvent
{
    [SerializeField] private List<Light2D> lights = new List<Light2D>();
    [SerializeField] private bool turnOffPlayerLights = true;

    public void Invoke()
    {
        if(turnOffPlayerLights)
        {
            var playerLights = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Light2D>();
            foreach(var light in playerLights)
            {
                light.enabled = !light.enabled;
            }
        }

        if (lights.IsNullOrEmpty()) return;

        foreach(var light in lights)
        {
            light.enabled = !light.enabled;
        }
    }
}
