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
    void Start()
    {
        CreateGride();
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

}

