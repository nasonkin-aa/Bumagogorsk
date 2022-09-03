using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    private const int gridSize = 20;
    public int GridSize
    {
        get
        {
            return gridSize;
        }
    }
    public GameObject[,] grid = new GameObject[gridSize, gridSize];
    public GameObject Diamond;

    
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
                grid[x, y] =  Instantiate(Diamond, new Vector3(transform.position.x + (x * 0.5f + 0.5f * y), transform.position.y + (y * 0.25f - 0.25f * x), 10), new Quaternion(),transform);
                grid[x, y].GetComponent<SpriteRenderer>().color = Random.ColorHSV(0,1,1,1,0.5f,1);
            }
        }
    }
}

