using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public List<GameObject> BuildingStayPlace = new List<GameObject>();
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "IsometricDiamond(Clone)")
        {
            BuildingStayPlace.Add(collision.gameObject);
            BuildingCheck();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "IsometricDiamond(Clone)")
        {
            BuildingStayPlace.Remove(collision.gameObject);
            BuildingCheck();
        }
        Debug.Log(BuildingStayPlace.Count);
    }
    private void BuildingCheck()
    {
        foreach (GameObject place in BuildingStayPlace)
        {
            for (int x = 0; x < Matrix.GridSize; x++)
            {
                for (int y = 0; y < Matrix.GridSize; y++)
                {
                    if (place == Matrix.Grid[x, y].Dimond && Matrix.Grid[x, y].State != Matrix.DiamodnStates.None)
                    {
                        Debug.Log("ddddddaaaaaa");
                        transform.GetComponent<SpriteRenderer>().color = Color.red;
                        return;
                    }
                }
            }
        }
        transform.GetComponent<SpriteRenderer>().color = Color.white;
    }
    
}
