using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building
{
  
    private void Awake()
    {
        _receivedResurece = 100;
        _type = BuildingType.Factory;
        Debug.Log(_receivedResurece+ " awake");
    }
    public override void GetResurse()
    {
        ResurceManager.AddPaper(_receivedResurece);
    }
}
