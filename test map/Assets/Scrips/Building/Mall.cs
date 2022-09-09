using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mall : Building
{
    void Awake()
    {
        _receivedResources = 300;
        _type = BuildingType.Mall;
    }
    public override void GetResurse()
    {
        //ResurceManager.add(_receivedResources);
    }

}
