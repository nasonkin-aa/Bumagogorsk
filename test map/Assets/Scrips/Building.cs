using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector2Int size = Vector2Int.one;
    public Renderer MainRender;

    public void SetTransparent(bool available)
    {
    
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("222222222222222222222222");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("!!!!!!!111111111111111111");
    }

    /*private void OnDrawGizmos()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Gizmos.matrix = this.transform.localToWorldMatrix;
                Gizmos.color = Color.red;

                //Gizmos.DrawCube;
            }
        }
    }*/

}
