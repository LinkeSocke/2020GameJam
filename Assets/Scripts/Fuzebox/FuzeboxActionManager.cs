using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FuzeboxActionManager : MonoBehaviour, IFuzeboxActionManager
{
    public abstract FuzeboxActionList GetActionsSequenceList();
}
