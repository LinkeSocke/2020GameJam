using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CameraRoute 
{
    public Transform startPoint;
    public Transform endPoint;
    public bool fadeAtEnd;
    public float waitAfterEnd;
    public float duration;
}
