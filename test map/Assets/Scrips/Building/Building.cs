using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    [SerializeField]
    protected BuildingType _type;
    protected int _receivedResurece;
    public enum BuildingType
    {
        Factory,
        House,
        CityHall,
        Mall
    }
    public void OnMouseDown()
    {
        GetResurse();
    }

    public abstract void GetResurse();

}
