using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mall : Building
{
    private int _cutPaperCost = 5;
    void Awake()
    {
        _receivedResources = 0;
        _receivedMaxResources = 50;
        _generationSpeed = 3;
        _type = BuildingType.Mall;
    }
    public override void GetResurse()
    {
        ResurceManager.AddCoins((int)_receivedResources);
    }
    public override bool TryToBuilding()
    {
        if (ResurceManager.CheckCutPaper(_cutPaperCost))
        {

            ResurceManager.ReduceCutPaper(_cutPaperCost);
            ResurceManager.AddExp(5);
            return true;
        }
        return false;
    }
   
}
