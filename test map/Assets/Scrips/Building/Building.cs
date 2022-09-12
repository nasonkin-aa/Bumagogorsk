using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    protected Coroutine buildingBehavor;
    [SerializeField]
    protected Slider progressSlider;
    protected bool IsMousDown;

    protected int _cutPaperCost ;
    protected int _populatyonCost = 0;
    protected int _coinCost = 0;
    protected int _exp = 0;

    public int GetBuildingType()
    {
        return (int)_type;
    }
    public enum BuildingType
    {
        Factory,
        House,
        CityHall,
        Mall,
        Roud
    }
    public void Start()
    {
        //this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void OnMouseDown()
    {
        IsMousDown = true;

    }
    public void OnMouseUp()
    {
        GetResurse();
        _receivedResources = 0;
       
    }
    public void CorutinStart()
    {
        StartCoroutine(AddResource());
    }
    public abstract void GetResurse();

    public  bool TryToBuilding()
    {

        Debug.Log(ResurceManager.CheckCutPaper((int)_cutPaperCost));
         
        var bola = ResurceManager.CheckCutPaper((int)_cutPaperCost) && ResurceManager.CheckCoins(_coinCost) && ResurceManager.CheckPopulation(_populatyonCost);
        return bola;
    }
    public void SpendCost()
    {
        ResurceManager.ReducePopulation(_populatyonCost);
        ResurceManager.ReduceCutPaper((int)_cutPaperCost);
        ResurceManager.ReduceCoins(_coinCost);
        ResurceManager.AddExp(_exp);
    }
    

    public  IEnumerator AddResource()
    {
        while (true)
        {
            if (_receivedResources < _receivedMaxResources)
            {
                _receivedResources +=  _generationSpeed * Time.deltaTime;
            }
            else
            {
                _receivedResources = _receivedMaxResources;
            }
            UpdateUI(_receivedResources, _receivedMaxResources);
            yield return null;
        }
    }
    public void UpdateUI(float current, float maxValue)
    {
        if(_type == BuildingType.Roud)
        {
            return;
        }
        progressSlider.value = current;
        progressSlider.maxValue = maxValue;
    }
   

}
