using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    private void Awake()
    {
        _type = BuildingType.House;
        _receivedResources = 0;
        _receivedMaxResources = 3;
        _generationSpeed = 1;
    }
    public override void GetResurse()
    {
        ResurceManager.AddPopulation((int)_receivedResources);
    }
}
