using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slicer2D;

public class CreatePaper : MonoBehaviour
{
    public GameObject paper;
    public int time = 2;
    private float timer = 0;

    private void Start()
    {
        Sliceable2D slicer = GetComponent<Sliceable2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > time)
        {
            GameObject newCactus = Instantiate(paper, transform.position, transform.rotation);
            timer = 0;
        }
        
        timer += Time.deltaTime;
    }
}
