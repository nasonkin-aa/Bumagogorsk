using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Building
{
    public void Awake()
    {
         _exp = 1;
         _cutPaperCost = 1;
         _coinCost = 0;
         _populatyonCost = 0;
    }

    public override void GetResurse()
    {
        return;
    }
}
