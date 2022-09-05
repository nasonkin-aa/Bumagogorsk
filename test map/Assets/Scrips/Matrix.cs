using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    private const int gridSize = 20;
    public static int GridSize => gridSize;

    private static MatrixElements[,] grid = new MatrixElements[gridSize, gridSize];
    public static MatrixElements[,] Grid => grid;

    public GameObject DiamondPrefab;

    public enum DiamondStates
    {
        None,
        Factory,
        House,
        CityHall,
        Roud
    }
    public struct MatrixElements
    {
        public GameObject DiamondInMatrix;
        public GameObject Building;
        public DiamondStates State;
    }
    void Start()
    {
        CreateGride();
    }
    private void CreateGride()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Debug.Log(grid.GetEnumerator());
                grid[x, y].DiamondInMatrix = Instantiate(DiamondPrefab, new Vector3(transform.position.x + (x * 0.5f + 0.5f * y), transform.position.y + (y * 0.25f - 0.25f * x), 5), new Quaternion(),transform);
                grid[x, y].DiamondInMatrix.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0,1,1,1,0.5f,1);
                grid[x, y].DiamondInMatrix.GetComponent<DiamondsInMatrixPosition>().DimondPos = new Vector2(x, y);
                grid[x, y].State = DiamondStates.None;
            }
        }
    }

}

