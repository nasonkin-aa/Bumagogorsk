using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building
{
  //cutpaper
    private void Awake()
    {
        _type = BuildingType.Factory;
        _receivedResources = 0;
        _receivedMaxResources = 100;
        _generationSpeed = 10;
        Debug.Log(_receivedResources+ " awake");

    }
    public override void GetResurse()
    {
        ResurceManager.AddPaper((int)_receivedResources);
    }
}
