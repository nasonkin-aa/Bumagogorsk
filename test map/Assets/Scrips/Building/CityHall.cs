using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityHall : Building
{
    void Awake()
    {
        _receivedResources = 0;
        _receivedMaxResources = 8;
        _generationSpeed = 5;
        _type = BuildingType.CityHall;
    }
    public override void GetResurse()
    {
        ResurceManager.AddPaper((int)_receivedResources);
    }

    public override bool TryToBuilding()
    {
        return true;
    }
}
