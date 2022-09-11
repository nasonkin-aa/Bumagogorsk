using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    private int _cutPaperCost = 10;
    private int _coinCost = 50;
    private void Awake()
    {
        //this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        _type = BuildingType.House;
        _receivedResources = 0;
        _receivedMaxResources = 3;
        _generationSpeed = 1;
    }
    public override void GetResurse()
    {
        ResurceManager.AddPopulation((int)_receivedResources);
    }
    public override bool TryToBuilding()
    {
        if (ResurceManager.CheckCutPaper(_cutPaperCost) && ResurceManager.CheckCoins(_coinCost))
        {
            ResurceManager.ReduceCutPaper(_cutPaperCost);
            ResurceManager.ReduceCoins(_coinCost);
            ResurceManager.AddExp(5);
            return true;
        }
        return false;
    }
}
