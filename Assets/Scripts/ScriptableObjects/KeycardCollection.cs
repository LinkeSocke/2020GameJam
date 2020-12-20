using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeycardCollection", menuName = "ScriptableObjects/KeycardCollection", order = 2)]
public class KeycardCollection : ScriptableObject
{
    public List<Keycard> keycards = new List<Keycard>();
}
