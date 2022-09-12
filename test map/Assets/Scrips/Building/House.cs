using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
   /* House() : base()
    {
        _exp = 4;
        _cutPaperCost = 10;
        _coinCost = 50;
        _populatyonCost = 0;
    }*/
    public void Awake()
    {
        _type = BuildingType.House;
        _exp = 4;
        _cutPaperCost = 10;
        _coinCost = 50;
        _populatyonCost = 0;
        //this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        _receivedResources = 0;
        _receivedMaxResources = 3;
        _generationSpeed = 1;
    }

    public override void GetResurse()
    {
        ResurceManager.AddPopulation((int)_receivedResources);
    }

  /*  public override bool TryToBuilding()
    {
        Debug.Log(_cutPaperCost);
        return ResurceManager.CheckCutPaper(_cutPaperCost) && ResurceManager.CheckCoins(_coinCost) && ResurceManager.CheckPopulation(_populatyonCost);
    }*/

}
