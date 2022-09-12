using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Building
{
    private int _cutPaperCost = 1;
    public override void GetResurse()
    {
    }

  
    public override bool TryToBuilding()
    {
        if (ResurceManager.CheckCutPaper(_cutPaperCost) )
        {
            ResurceManager.ReduceCutPaper(_cutPaperCost);
            ResurceManager.AddExp(1);
            return true;
        }
        return false;
    }

}
