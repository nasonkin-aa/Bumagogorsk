using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityHall : Building
{
    void Awake()
    {
        _receivedResources = 0;
        _receivedMaxResources = 50;
        _generationSpeed = 1;
        _type = BuildingType.CityHall;
    }
    public override void GetResurse()
    {
        ResurceManager.AddPaper((int)_receivedResources);
    } 
}
