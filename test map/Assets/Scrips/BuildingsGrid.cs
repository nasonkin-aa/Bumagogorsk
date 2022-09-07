using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    public Vector2Int SizeGrid = new Vector2Int(100,100);

    private Building[,] grid;
    private Building flyingBuildings;

    private Camera mainCamera;
    public DiamondPosition dp;

    public Matrix matrix;

    private void Awake()
    {
        grid = new  Building[SizeGrid.x,SizeGrid.y];
        mainCamera = Camera.main;
    }

    public void StartPlacingBuilding(Building buildingsPrefab)
    {
        if(flyingBuildings != null)
        { 
            Destroy(flyingBuildings.gameObject);
        }
        flyingBuildings = Instantiate(buildingsPrefab);
    }
    void Update()
    { 
        if (flyingBuildings != null)
        {
            flyingBuildings.transform.position = new Vector3(dp.DiamondPos.x, dp.DiamondPos.y, dp.DiamondPos.y * 0.1f);
            CheckPlace();
        }
    }
    private void CheckPlace()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject place in flyingBuildings.BuildingStayPlace)
            {
                Matrix.Grid[(int)place.GetComponent<DiamondsInMatrixPosition>().DimondPos.x,
                (int)place.GetComponent<DiamondsInMatrixPosition>().DimondPos.y].State = Matrix.DiamondStates.House;
            }
            flyingBuildings = null;
        }
    }

}
