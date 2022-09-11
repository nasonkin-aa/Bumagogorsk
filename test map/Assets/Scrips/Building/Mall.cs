using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mall : Building
{
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

}
