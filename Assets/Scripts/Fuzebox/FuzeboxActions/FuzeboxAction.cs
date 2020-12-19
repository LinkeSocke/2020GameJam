using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultFuzeboxAction", menuName = "ScriptableObjects/DefaultFuzeboxAction", order = 1)]
public class FuzeboxAction : ScriptableObject, IFuzeboxAction
{
    [SerializeField]
    private string actionValue = "No Action";

    public string GetValue()
    {
        return actionValue;
    }
}
