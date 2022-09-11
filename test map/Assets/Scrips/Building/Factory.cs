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
        _receivedMaxResources = 20;
        _generationSpeed = 0.5f;
    }
    public override void GetResurse()
    {
        ResurceManager.AddCutPaper((int)_receivedResources);
    }
}
