using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultFuzeboxAction", menuName = "ScriptableObjects/Fuzebox/DefaultFuzeboxAction", order = 1)]
public class FuzeboxAction : ScriptableObject, IFuzeboxAction
{
    [SerializeField]
    protected string actionValue = "No Action";

    public string GetValue()
    {
        return actionValue;
    }
}
