using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    private const int gridSizeX = 38;
    private const int gridSizeY = 25;
    //public static int GridSize => gridSize;

    private static MatrixElements[,] grid = new MatrixElements[gridSizeX, gridSizeY];
    public static MatrixElements[,] Grid => grid;

    public GameObject DiamondPrefab;

    public GameObject CityHoll;
    public GameObject Road;


    public static bool IsFree(int x, int y) => grid[x, y].State != DiamondStates.None;
   
    public enum DiamondStates
    {
        Factory,
        House,
        CityHall,
        Mall,
        Roud,
        None
    }
    public struct MatrixElements
    {
        public GameObject DiamondInMatrix;
        public GameObject Building;
        public DiamondStates State;
    }
    public enum sides
    {
        left,
        down,
        right,
        top,
    }
    public static Dictionary<sides,MatrixElements> GetNeiborhood(int x, int y)
    {
        var list2 = new Dictionary<sides, MatrixElements>();
        var counter = 0;
            for(int i = -1; i < 2; i += 2)
            {
                if (0 <= i + x && i + x < gridSizeX && 0 <= y  && y < gridSizeY)
                    if (grid[x + i,y].State == DiamondStates.Roud)
                        list2.Add((sides)counter, grid[x + i, y]);
                counter++;
                if (0 <= x && x < gridSizeX && 0 <= i + y && i + y < gridSizeY)
                    if (grid[x , y + i].State == DiamondStates.Roud)
                        list2.Add((sides)counter, grid[x, y + i]);
                counter++;
            }
        return list2;
    }
    void Awake()
    {
        CreateGride();
    }
    private void Start()
    {
        BuildinInit();

    }
    private void CreateGride()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                //Debug.Log(grid.GetEnumerator());
                grid[x, y].DiamondInMatrix = Instantiate(DiamondPrefab, new Vector3(transform.position.x + (x * 0.5f + 0.5f * y), transform.position.y + (y * 0.25f - 0.25f * x), 5), new Quaternion(),transform);
                //grid[x, y].DiamondInMatrix.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0,1,1,1,0.5f,1);
                grid[x, y].DiamondInMatrix.GetComponent<SpriteRenderer>().color = new Color(0.94617f, 0.91380f, 0.861123f);
                grid[x, y].DiamondInMatrix.GetComponent<DiamondsInMatrixPosition>().DimondPos = new Vector2(x, y);
                grid[x, y].State = DiamondStates.None;
            }
        }
    }
     private void BuildinInit()
    {
        for (int i = 20; i < 26; i++)
            CreateDefaultRoad(new Vector2Int (i, 11));
        CreateDefaultCityHall(new Vector3(-0.321963072f, -0.708952248f, -0.0708952248f));
    }

    private void CreateDefaultRoad(Vector2Int pos)
    {
        grid[pos.x, pos.y].Building = Instantiate(Road, grid[pos.x, pos.y].DiamondInMatrix.transform.position,Quaternion.identity);
        grid[pos.x, pos.y].State = (DiamondStates)grid[pos.x, pos.y].Building.GetComponent<Building>().GetBuildingType();
        grid[pos.x, pos.y].Building.GetComponent<Collider2D>().enabled = false;
        grid[pos.x, pos.y].Building.transform.rotation = Quaternion.Euler(0, 180, 0);
        grid[pos.x, pos.y].Building.GetComponent<BuildingCollisionController>().BuildingStayPlace.Add(grid[pos.x, pos.y].DiamondInMatrix);
    }

    private void CreateDefaultCityHall(Vector3 pos)
    {
        GameObject cityHall = Instantiate(CityHoll, pos, Quaternion.identity);
        cityHall.GetComponent<Building>().CorutinStart();
        cityHall.GetComponent<Collider2D>().enabled = false;
        for (int x = 21; x <= 24; x++)
            for (int y = 12; y <= 14; y++)
            {
                grid[x, y].Building = cityHall;
                grid[x, y].State = (DiamondStates)grid[x, y].Building.GetComponent<Building>().GetBuildingType();
                grid[x, y].Building.GetComponent<BuildingCollisionController>().BuildingStayPlace.Add(grid[x, y].DiamondInMatrix);
            }
    }
}

