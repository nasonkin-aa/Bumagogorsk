using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slicer2D;

public class DebugSlice : MonoBehaviour
{
    public void Start()
    {
        EventHandling.globalSliceResultEvent += DebugLogerSlice;
    }

    void DebugLogerSlice(Slice2D slice)
    {
        float startLocalX = (float) slice.slice[0].x - slice.originGameObject.transform.position.x;
        float startLocalY = (float)slice.slice[0].y - slice.originGameObject.transform.position.y;
        float endLocalX = (float)slice.slice[1].x - slice.originGameObject.transform.position.x;
        float endLocalY = (float)slice.slice[1].y - slice.originGameObject.transform.position.y;

        float x1 = slice.originGameObject.GetComponent<LineDraw>().p1.x;
        float x2 = slice.originGameObject.GetComponent<LineDraw>().p1.y;
        float x3 = slice.originGameObject.GetComponent<LineDraw>().p2.x;
        float x4 = slice.originGameObject.GetComponent<LineDraw>().p2.y;

        double cutPerfect = 0;

        if (Mathf.Abs(x1) == slice.originGameObject.transform.localScale.x / 2)
        {
            if (x1 < 0 && startLocalX < 0)
            {
                cutPerfect = Mathf.Abs(startLocalY - x2) + Mathf.Abs(endLocalY - x4);
            } else
                cutPerfect = Mathf.Abs(startLocalY - x4) + Mathf.Abs(endLocalY - x2);
        } else
        {
            if (x2 < 0 && startLocalY < 0)
            {
                cutPerfect = Mathf.Abs(startLocalX - x1) + Mathf.Abs(endLocalX - x3);
            }
            else
                cutPerfect = Mathf.Abs(startLocalX - x3) + Mathf.Abs(endLocalX - x1);
        }
        UnityEngine.Debug.Log(cutPerfect);
        if (cutPerfect < (slice.originGameObject.transform.localScale.x + slice.originGameObject.transform.localScale.y) / 10)
        {
            //UnityEngine.Debug.Log("Good");
        }
        else
            //UnityEngine.Debug.Log("Bad");

        /*UnityEngine.Debug.Log("StartCut: " + startLocalX + " " + startLocalY + " " + x1 + " " + x2);
        UnityEngine.Debug.Log("EndCut: " + endLocalX + " " + endLocalY + " " + x3 + " " + x4);*/
        UnityEngine.Debug.Log(slice.originGameObject.transform.localScale.x+ " " +slice.originGameObject.transform.localScale.y);
        UnityEngine.Debug.Log((slice.originGameObject.transform.localScale.x + slice.originGameObject.transform.localScale.y) / 10);

    }

}
