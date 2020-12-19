using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[ExecuteAlways]
public class FuzeManager : FuzeboxActionManager
{
    [SerializeField]
    FuzeActionButton[] fuzeSlots;

    private void OnEnable()
    {
        GatherFuzeSlots();
    }

    private void Start()
    {
        GatherFuzeSlots();
    }

    void GatherFuzeSlots()
    {
        fuzeSlots = GetComponentsInChildren<FuzeActionButton>();
    }

    public FuzeboxActionList GetFuzeList()
    {
        FuzeboxActionList selectedFuzes = new FuzeboxActionList();
        if (fuzeSlots.Length <= 0)
            throw new System.Exception("FuzeManager is missing Fuze Slots.");

        foreach(FuzeActionButton fuzeSlot in fuzeSlots)
        {
            selectedFuzes.Add(fuzeSlot.GetSelectedFuze());
        }

        if(selectedFuzes.Length <= 0)
            throw new System.Exception("FuzeSlots of FuzeManager are missing selected Fuzes.");


        return selectedFuzes;
    }

    public override FuzeboxActionList GetActionsSequenceList()
    {
        return GetFuzeList();
    }
}
