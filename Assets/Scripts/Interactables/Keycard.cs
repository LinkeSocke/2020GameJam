using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EKeycardType { BLUE, RED, GREEN }

public class Keycard : ScriptableObject
{
    public EKeycardType keycardType = EKeycardType.BLUE;
}
