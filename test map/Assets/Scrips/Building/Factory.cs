using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building
{
    //cutpaper
   
    public void Awake()
    {
        _exp = 5;
        _cutPaperCost = 10;
        _populatyonCost = 10;
        _coinCost = 11;
        _type = BuildingType.Factory;
        _receivedResources = 0;
        _receivedMaxResources = 20;
        _generationSpeed = 0.5f;
    }
    public override void GetResurse()
    {
        ResurceManager.AddCutPaper((int)_receivedResources);
    }
}
