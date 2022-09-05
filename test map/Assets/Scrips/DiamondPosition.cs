using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiamondPosition : MonoBehaviour
{
    private Camera mainCamera;

    public Vector2 DiamondPos;
    //public string[] BuildingStay;
    public RaycastHit2D hitDiamond;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {   
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        RaycastHit2D hit = Physics2D.Raycast( worldPoint, Vector2.zero );

        if ( hit.collider != null && hit.collider.name == "IsometricDiamond(Clone)" && hit.collider.gameObject)
        {
            hitDiamond = hit;
            DiamondPos = hit.transform.position;
        }
        
    }

}
