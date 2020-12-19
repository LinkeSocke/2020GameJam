using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee.List;

[CreateAssetMenu(fileName = "FuzeboxActionSequence", menuName = "ScriptableObjects/FuzeboxActionSequence", order = 1)]
public class FuzeboxActionSequence : ScriptableObject
{
 
        [Reorderable]
        public FuzeboxActionList fuzeboxActionSequence;


}
