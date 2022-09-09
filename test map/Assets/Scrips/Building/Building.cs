using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    [SerializeField]
    protected BuildingType _type;
    [SerializeField]
    protected float _receivedResources;
    [SerializeField]
    protected float _receivedMaxResources;
    [SerializeField] 
    protected float _generationSpeed;

    protected Coroutine buildingBehavor;
    public enum BuildingType
    {
        Factory,
        House,
        CityHall,
        Mall
    }
    public void OnMouseUp()
    {
        GetResurse();
        StartCoroutine(AddResource());
        _receivedResources = 0;

    }
    public abstract void GetResurse();

    protected IEnumerator AddResource()
    {
        while (true)
        {
            if(_receivedResources < _receivedMaxResources)
            {
                _receivedResources += _generationSpeed * Time.deltaTime;
            }
            else
            {
                _receivedResources = _receivedMaxResources;
            }
            yield return null;
        }
    }

}
