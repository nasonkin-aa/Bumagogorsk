using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    private void Awake()
    {
        _receivedResources = 1;
        _type = BuildingType.House;
    }
    public override void GetResurse()
    {
        ResurceManager.AddPopulation((int)_receivedResources);
    }
}
