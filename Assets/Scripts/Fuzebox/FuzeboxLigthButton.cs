using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee.List;

public class FuzeboxLigthButton : MonoBehaviour
{

    [SerializeField]
    [Reorderable]
    FuzeboxActionManagerList actionManagers;

    [SerializeField]
    FuzeboxActionSequence correctActionSequence;

    FuzeboxActionList correctSequenceList;

    private void Awake()
    {
        loadCorrectSequence();
    }

    void loadCorrectSequence()
    {
        correctSequenceList = correctActionSequence.GetActionSequence();
    }

    public void Submit()
    {
        if (CheckCorrectSequence())
            Debug.Log("Correct");
        else
            Debug.Log("Incorrect");
    }

    bool CheckCorrectSequence()
    {

        FuzeboxActionList combinedPlayerSequence = GetCombinedPlayerSequence();
        if(combinedPlayerSequence.Length < correctSequenceList.Length)
        {
            Debug.Log("Player input Sequence too short.");
            return false;
        }

        #region Debug Test
        //Debug.Log($"Correct Sequence: {correctSequenceList.ToString()}");
        //foreach(FuzeboxAction action in correctSequenceList)
        //{
        //    Debug.Log(action.GetValue());
        //}

        //Debug.Log($"Input Sequence: {combinedPlayerSequence.ToString()}");
        //foreach (FuzeboxAction action in combinedPlayerSequence)
        //{
        //    Debug.Log(action.GetValue());
        //}
        #endregion

        for (int i = 0; i < correctSequenceList.Length; i++)
        {
            if (!correctSequenceList[i].Equals(combinedPlayerSequence[i]))
            {
                return false;
            }
        }
        return true;
    }

    FuzeboxActionList GetCombinedPlayerSequence()
    {
        FuzeboxActionList combinedSequences = new FuzeboxActionList();
        foreach(FuzeboxActionManager fam in actionManagers)
        {
            FuzeboxActionList fal = fam.GetActionsSequenceList();
            if (fal == null)
                throw new System.Exception($"Empty list in {fam}.");

            foreach(FuzeboxAction fa in fam.GetActionsSequenceList())
            {
                combinedSequences.Add(fa);
            }
        }
        return combinedSequences;
    }

    [System.Serializable]
    public class FuzeboxActionManagerList : ReorderableArray<FuzeboxActionManager>
    {
    }
}
