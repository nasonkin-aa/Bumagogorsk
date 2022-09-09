using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    LineRenderer l;
    public Vector3 p1, p2;
    private void Awake()
    {
        l = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        l.positionCount = 2;
        if (Random.Range(0,100) > 50)
        {
            p1 = new Vector3(-transform.lossyScale.x / 2, Random.Range(-transform.lossyScale.y / 2.1f, transform.lossyScale.y / 2.1f), 0);
            p2 = new Vector3(transform.lossyScale.x / 2, Random.Range(-transform.lossyScale.y / 2.1f, transform.lossyScale.y / 2.1f), 0);
        } 
        else
        {
            p1 = new Vector3(Random.Range(-transform.lossyScale.x / 2.1f, transform.lossyScale.x / 2.1f), -transform.lossyScale.y / 2, 0);
            p2 = new Vector3(Random.Range(-transform.lossyScale.x / 2.1f, transform.lossyScale.x / 2.1f), transform.lossyScale.y / 2, 0);
        }
    }

    void Update()
    {
        l.SetPosition(0, transform.position + p1);
        l.SetPosition(1, transform.position + p2);
    }
}
