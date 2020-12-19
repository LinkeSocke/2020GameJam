using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzeboxActivate : MonoBehaviour
{
    public void Activate()
    {
        GameManager.Instance.FinishLevel();
    }
}
