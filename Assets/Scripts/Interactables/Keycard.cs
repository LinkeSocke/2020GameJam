using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EKeycardType { BLUE, RED, GREEN }

[CreateAssetMenu(fileName = "Keycard", menuName = "ScriptableObjects/Keycard", order = 1)]
public class Keycard : ScriptableObject
{
    public EKeycardType keycardType = EKeycardType.BLUE;
    public Color keycardColor = Color.blue;
    public Sprite doorSprite = null;
}
