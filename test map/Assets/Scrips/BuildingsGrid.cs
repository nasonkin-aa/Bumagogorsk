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

    public BuildingCollisionController roadInstans;

    private void Awake()
    {
        grid = new BuildingCollisionController[SizeGrid.x,SizeGrid.y];
        mainCamera = Camera.main;
      /*  var pos = Matrix.Grid[18, 12].DiamondInMatrix.transform.position;
        flyingBuildings = Instantiate(roadInstans, new Vector3(pos.x, pos.y, pos.y * 0.1f), Quaternion.identity);
        flyingBuildings.GetComponent<BoxCollider2D>().enabled = false;
        //MatrixAddElement(new Vector2(18, 12));
        flyingBuildings.GetComponent<BoxCollider2D>().enabled = true;
        flyingBuildings = null;*/
    }
    public void Start()
    {
      
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
            /*var listNeiborhood = new List<Matrix.DiamondStates>();*/
            foreach (GameObject place in flyingBuildings.BuildingStayPlace)
            {
                var ComponentDIP = place.GetComponent<DiamondsInMatrixPosition>().DimondPos;
                /*foreach (var neibor in Matrix.GetNeiborhood((int)ComponentDIP.x, (int)ComponentDIP.y))
                {
                    listNeiborhood.Add(neibor.Value.State);
                }*/

                MatrixAddElement(ComponentDIP);

                if (flyingBuildings.GetComponent<Building>().GetBuildingType() == (int)Matrix.DiamondStates.Roud)
                {
                    CreatRoad(ComponentDIP);
                    return;
                }
            }
            /*if (listNeiborhood.Contains(Matrix.DiamondStates.Roud))*/
            {
                flyingBuildings.GetComponent<Building>().CorutinStart();
                flyingBuildings.GetComponent<Building>().SpendCost();
                flyingBuildings.gameObject.layer = 8;
                flyingBuildings = null;
            }
        }
    }

    private void CreatRoad(Vector2 ComponentDIP)
    {
        RoadManager.OnRoadPlase(flyingBuildings.gameObject, (int)ComponentDIP.x, (int)ComponentDIP.y, Road);
        flyingBuildings.GetComponent<Building>().SpendCost();
        flyingBuildings.gameObject.layer = 8;
        flyingBuildings = null;
        var neiborhood = Matrix.GetNeiborhood((int)ComponentDIP.x, (int)ComponentDIP.y);

        foreach (var neighbor in neiborhood)
        {
            //neighbor.Value.Building.GetComponent<Collider2D>().enabled = true;
            var pos = neighbor.Value.Building.GetComponent<BuildingCollisionController>().BuildingStayPlace[0].GetComponent<DiamondsInMatrixPosition>().DimondPos;

            RoadManager.OnRoadPlase(neighbor.Value.Building, (int)pos.x, (int)pos.y, Road);
        }
        if (roadInstans.GetComponent<Building>().TryToBuilding())
            flyingBuildings = Instantiate(roadInstans);
    }

    private void MatrixAddElement(Vector2 ComponentDIP)
    {
        Matrix.Grid[(int)ComponentDIP.x, (int)ComponentDIP.y].State =
            (Matrix.DiamondStates)flyingBuildings.GetComponent<Building>().GetBuildingType();

        Matrix.Grid[(int)ComponentDIP.x, (int)ComponentDIP.y].Building = flyingBuildings.gameObject;
    }
}
