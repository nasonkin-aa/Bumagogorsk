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
            /* Matrix.Grid[(int)collision.gameObject.GetComponent<DiamondsInMatrixPosition>().DimondPos.x,
                (int)collision.gameObject.GetComponent<DiamondsInMatrixPosition>().DimondPos.y].State = Matrix.DiamondStates.House;*/
            
            BuildingStayPlace.Add(collision.gameObject);
            BuildingCheck();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "IsometricDiamond(Clone)")
        {
            /*Matrix.Grid[(int)collision.gameObject.GetComponent<DiamondsInMatrixPosition>().DimondPos.x,
               (int)collision.gameObject.GetComponent<DiamondsInMatrixPosition>().DimondPos.y].State = Matrix.DiamondStates.None;*/

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
                Debug.Log("ddddddaaaaaa");
                transform.GetComponent<SpriteRenderer>().color = Color.red;
                return;
            }
        }
        transform.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject place in BuildingStayPlace)
            {
                Matrix.Grid[(int)place.GetComponent<DiamondsInMatrixPosition>().DimondPos.x,
                (int)place.GetComponent<DiamondsInMatrixPosition>().DimondPos.y].State = Matrix.DiamondStates.House;
            }

        }
    }
}
 