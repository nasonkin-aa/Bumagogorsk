using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollisionController : MonoBehaviour
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
        var listNeiborhood = new List<Matrix.DiamondStates>();
        foreach (GameObject place in BuildingStayPlace)
        {
            var diamondPos = place.GetComponent<DiamondsInMatrixPosition>().DimondPos;
            foreach (var neibor in Matrix.GetNeiborhood((int)diamondPos.x, (int)diamondPos.y))
            {
                listNeiborhood.Add(neibor.Value.State);
            }
            if (Matrix.IsFree((int)diamondPos.x, (int)diamondPos.y))
            {
                transform.GetComponent<SpriteRenderer>().color = Color.red;
                return;
            }
        }
            transform.GetComponent<SpriteRenderer>().color = Color.white;

        if (!listNeiborhood.Contains(Matrix.DiamondStates.Roud) /*&& transform.GetComponent<Building>().GetBuildingType() != (int)Building.BuildingType.Roud*/)
            transform.GetComponent<SpriteRenderer>().color = Color.red;

    }
}
 