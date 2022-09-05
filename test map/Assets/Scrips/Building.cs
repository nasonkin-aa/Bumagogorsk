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
    }
    private void BuildingCheck()
    {
        foreach (GameObject place in BuildingStayPlace)
        {
            if (Matrix.Grid[(int)place.GetComponent<DiamondsInMatrixPosition>().DimondPos.x,
               (int)place.GetComponent<DiamondsInMatrixPosition>().DimondPos.y].State != Matrix.DiamondStates.None)
            {
                transform.GetComponent<SpriteRenderer>().color = Color.red;
                return;
            }
        }
        transform.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
 