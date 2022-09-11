using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building
{
    //cutpaper
    private int _cutPaperCost = 10;
    private int _populatyonCost = 10;
    private int _coinCost = 11;
    private void Awake()
    {
        _type = BuildingType.Factory;
        _receivedResources = 0;
        _receivedMaxResources = 20;
        _generationSpeed = 0.5f;
    }
    public override void GetResurse()
    {
        ResurceManager.AddCutPaper((int)_receivedResources);
    }
    public override bool TryToBuilding()
    {
        if (ResurceManager.CheckCutPaper(_cutPaperCost) && ResurceManager.CheckCoins(_coinCost) && ResurceManager.CheckPopulation(_populatyonCost))
        {
            ResurceManager.ReducePopulation(_populatyonCost);
            ResurceManager.ReduceCutPaper(_cutPaperCost);
            ResurceManager.ReduceCoins(_coinCost);
            ResurceManager.AddExp(5);
            return true;
        }
        return false;
    }
}
