using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public static void OnRoadPlase(GameObject go, int x,int y, GameObject Road )
    {
        var List = Matrix.GetNeiborhood(x,y);
        var ListCount = List.Count;
        Debug.Log(ListCount);
        switch (ListCount)
        {
            case 0:
                break;
            case 1:
                if( List.ContainsKey(Matrix.sides.left) || List.ContainsKey(Matrix.sides.right))
                    go.transform.rotation = Quaternion.Euler(0,180,0);
                break;
            case 2:
                if(List.ContainsKey(Matrix.sides.left) && List.ContainsKey(Matrix.sides.right))
                {
                    go.transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                }
                if (List.ContainsKey(Matrix.sides.top) && List.ContainsKey(Matrix.sides.down))
                {
                    break;
                }
                go.GetComponent<SpriteRenderer>().sprite = Road.GetComponent<SpriteRenderer>().sprite;
                break;
            default:
                go.GetComponent<SpriteRenderer>().sprite = Road.GetComponent<SpriteRenderer>().sprite;
                break;
        }
    }
}
