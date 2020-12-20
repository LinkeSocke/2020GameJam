using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FuzeAction", menuName = "ScriptableObjects/Fuzebox/FuzeAction", order = 1)]
public class FuzeAction : FuzeboxAction
{
    [SerializeField]
    private Sprite fuzeImage;

    public Sprite GetFuzeImage()
    {
        return fuzeImage;
    }
}
