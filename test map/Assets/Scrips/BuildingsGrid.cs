using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    public Vector2Int SizeGrid = new Vector2Int(100,100);

    private BuildingCollisionController[,] grid;
    private BuildingCollisionController flyingBuildings;

    private Camera mainCamera;
    public DiamondPosition dp;

    public Matrix matrix;

    public GameObject Road;

    private void Awake()
    {
        grid = new BuildingCollisionController[SizeGrid.x,SizeGrid.y];
        mainCamera = Camera.main;
    }

    public void StartPlacingBuilding(BuildingCollisionController buildingsPrefab)
    {
        if (!buildingsPrefab.GetComponent<Building>().TryToBuilding())
        {
            return;
        }
        if(flyingBuildings != null)
        {
            Destroy(flyingBuildings.gameObject);
        }

        if (flyingBuildings != null && flyingBuildings.GetComponent<Building>().GetBuildingType() == (int)Matrix.DiamondStates.Roud)
        {
            Destroy(flyingBuildings.gameObject);
            return;
        }
        flyingBuildings = Instantiate(buildingsPrefab);
    }

    void Update()
    { 
        if (flyingBuildings != null )
        {
            flyingBuildings.transform.position = new Vector3(dp.DiamondPos.x, dp.DiamondPos.y, dp.DiamondPos.y * 0.1f);
            CheckPlace();
        }
    }
    private void CheckPlace()
    {
        if (Input.GetMouseButtonDown(0) && flyingBuildings.GetComponent<SpriteRenderer>().color != Color.red )
        {
            foreach (GameObject place in flyingBuildings.BuildingStayPlace)
            {
                var ComponentDIP = place.GetComponent<DiamondsInMatrixPosition>().DimondPos;

                Matrix.Grid[(int)ComponentDIP.x,(int)ComponentDIP.y].State = 
                    (Matrix.DiamondStates)flyingBuildings.GetComponent<Building>().GetBuildingType();

                Matrix.Grid[(int)ComponentDIP.x,(int)ComponentDIP.y].Building = flyingBuildings.gameObject;

                if (flyingBuildings.GetComponent<Building>().GetBuildingType() == (int)Matrix.DiamondStates.Roud)
                {
                    //var flyB = Instantiate( flyingBuildings);
                    RoadManager.OnRoadPlase(flyingBuildings.gameObject,(int)ComponentDIP.x,(int)ComponentDIP.y, Road);

                    flyingBuildings = null;
                    var neiborhood = Matrix.GetNeiborhood((int)ComponentDIP.x,(int)ComponentDIP.y);
                    
                    foreach (var neighbor in neiborhood)
                    {
                        var pos = neighbor.Value.GetComponent<BuildingCollisionController>().BuildingStayPlace[0].GetComponent<DiamondsInMatrixPosition>().DimondPos;

                        RoadManager.OnRoadPlase(neighbor.Value,(int)pos.x,(int)pos.y, Road);
                    }    
                  //  flyingBuildings = flyB;
                    return;
                }
            }
            flyingBuildings.GetComponent<Building>().CorutinStart();
            flyingBuildings = null;
        }
    }

}
