using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Image))]
public class FuzeActionButton : MonoBehaviour
{
    [SerializeField]
    FuzeboxActionSequence fuzeActionOptions;

    FuzeboxActionList fuzeActionOptionsList;
    int currOptionIndex = 0;

    [SerializeField]
    FuzeAction currentFuzeAction;

    Image btnImage;

    private void OnEnable()
    {
        btnImage = GetComponent<Image>();
        if(fuzeActionOptions == null) 
            Debug.LogWarning("Fuze Button is missing fuze Options", gameObject);
        else
        {
            fuzeActionOptionsList = fuzeActionOptions.GetActionSequence();
            if (fuzeActionOptionsList.Length <= 0)
                Debug.LogWarning("Fuze Options in Button are empty.", gameObject);
            else
            {
                currOptionIndex = ((int)(Random.value * 100)) % fuzeActionOptionsList.Length;

                if (!fuzeActionOptionsList[currOptionIndex].GetType().Equals(typeof(FuzeAction)))
                    Debug.LogWarning($"Fuze Options contians Element that isn't a Fuze Action. At Index {currOptionIndex}", gameObject);
                else
                {
                    currentFuzeAction = (FuzeAction)fuzeActionOptionsList[currOptionIndex];
                    btnImage.sprite = currentFuzeAction.GetFuzeImage();
                }
            }
        }
    }



    public void CycleFuzeActions()
    {
        currOptionIndex = (currOptionIndex + 1) % fuzeActionOptionsList.Length;
        if (!fuzeActionOptionsList[currOptionIndex].GetType().Equals(typeof(FuzeAction)))
            Debug.LogWarning($"Fuze Options contians Element that isn't a Fuze Action. At Index {currOptionIndex}", gameObject);
        else
        {
            currentFuzeAction = (FuzeAction)fuzeActionOptionsList[currOptionIndex];
            btnImage.sprite = currentFuzeAction.GetFuzeImage();
        }
    }

    public FuzeAction GetSelectedFuze()
    {
        return currentFuzeAction;
    }
}
