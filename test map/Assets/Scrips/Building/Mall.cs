using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mall : Building
{
    void Awake()
    {
        _exp = 3;
        _cutPaperCost = 5;
        _populatyonCost = 0;
        _coinCost = 0;
        _receivedResources = 0;
        _receivedMaxResources = 50;
        _generationSpeed = 3;
        _type = BuildingType.Mall;
    }
    public override void GetResurse()
    {
        ResurceManager.AddCoins((int)_receivedResources);
    }
 
}
