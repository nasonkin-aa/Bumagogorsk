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
            Debug.Log(BuildingStayPlace);
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
            var diamondPos = place.GetComponent<DiamondsInMatrixPosition>().DimondPos;
            if (Matrix.IsFree((int)diamondPos.x, (int)diamondPos.y))
            {
                transform.GetComponent<SpriteRenderer>().color = Color.red;
                return;
            }
        }
        transform.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
 