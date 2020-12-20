using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightEvent : MonoBehaviour, IGameEvent
{
    [SerializeField] private List<Light2D> lights = new List<Light2D>();
    [SerializeField] private bool turnOffPlayerLights = true;
    [SerializeField] private string lightTag;
    [SerializeField] private float globalLightIntensity = 0.8f;

    public void Invoke()
    {
        if (!string.IsNullOrEmpty(lightTag))
        {
            var foundLight = GameObject.FindGameObjectsWithTag(lightTag);
            foreach(var light in foundLight)
            {
                lights.Add(light.GetComponent<Light2D>());
            }
        }

        if(turnOffPlayerLights)
        {
            var playerLights = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Light2D>();
            foreach(var light in playerLights)
            {
                light.gameObject.SetActive(false);
            }
        }

        if (lights.IsNullOrEmpty()) return;

        foreach(var light in lights)
        {
            if(light.lightType == Light2D.LightType.Global)
            {
                light.intensity = globalLightIntensity;
            }
            else
            {
                light.enabled = false;
            }
        }
    }
}
