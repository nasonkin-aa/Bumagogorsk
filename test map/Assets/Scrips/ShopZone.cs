using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopZone : MonoBehaviour
{
    private bool DestroyIsActive = false;
    public void OnTriggerExit2D(Collider2D collision)
    {
        DestroyIsActive = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (DestroyIsActive)
        {
            Destroy(collision.gameObject);
        }
        DestroyIsActive = false;
    }
}
