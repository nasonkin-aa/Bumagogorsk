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

    public List<GameObject> BuildingStay = new List<GameObject>();


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
            flyingBuildings.transform.position = new Vector3(dp.DiamondPos.x, dp.DiamondPos.y, 1);
            CheckPlace();
        }
    }
    private void CheckPlace()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (dp.hitDiamond.collider.gameObject == Matrix.Grid[x, y].Dimond.gameObject
                        && (!BuildingStay.Contains(Matrix.Grid[x, y].Dimond.gameObject)))
                    {
                        BuildingStay.Add(Matrix.Grid[x, y].Dimond);
                        Debug.Log(BuildingStay.Count);
                        Debug.Log(x + "   " + y);
                    }
                }
            }
            flyingBuildings = null;
        }
    }

}
