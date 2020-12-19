using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee.List;

[CreateAssetMenu(fileName = "FuzeboxActionSequence", menuName = "ScriptableObjects/Fuzebox/FuzeboxActionSequence", order = 1)]
public class FuzeboxActionSequence : ScriptableObject
{
    [SerializeField]
    [Multiline]
    private string description = "Sequence for Box A (example).";
 
    [Header("Action Sequence:")]
    [Reorderable]
    [SerializeField]
    private FuzeboxActionList fuzeboxActionSequence;

    public FuzeboxActionList GetActionSequence()
    {
        return fuzeboxActionSequence;
    }


}
