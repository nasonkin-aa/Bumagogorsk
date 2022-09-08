using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityHall : Building
{
    void Start()
    {
        _receivedResurece = 2;
        _type = BuildingType.CityHall;
    }
    public override void GetResurse()
    {
        ResurceManager.AddPaper(_receivedResurece);
    } 
}
