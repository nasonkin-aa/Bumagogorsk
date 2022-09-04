using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    private const int gridSize = 20;
    public static int GridSize => gridSize;

    private static MatrixElements[,] grid = new MatrixElements[gridSize, gridSize];
    public static MatrixElements[,] Grid => grid;

    public GameObject Diamond;

    public enum DiamodnStates
    {
        None,
        Factory,
        House,
        CityHall,
        Roud
    }
    public struct MatrixElements
    {
        public GameObject Dimond;
        public GameObject Building;
        public DiamodnStates State;
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
                grid[x, y].Dimond = Instantiate(Diamond, new Vector3(transform.position.x + (x * 0.5f + 0.5f * y), transform.position.y + (y * 0.25f - 0.25f * x), 5), new Quaternion(),transform);
                grid[x, y].Dimond.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0,1,1,1,0.5f,1);
                //grid[x, y].State = DiamodnStates.None;
                grid[x, y].State = DiamodnStates.None;
            }
        }
    }

}

