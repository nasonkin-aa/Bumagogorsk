using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TintRedHud : MonoBehaviour
{
    public GameObject[] listoch;
    public GameObject[] people;
    public GameObject[] paper;
    void Start()
    {
    }
    private void Update()
    {
        foreach (GameObject list in listoch)
        {
            if (int.Parse(list.transform.GetChild(0).GetComponent<Text>().text.ToString()) > ResurceManager._coins)
            {
                list.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                list.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        foreach (GameObject peop in people)
        {
            if (int.Parse(peop.transform.GetChild(0).GetComponent<Text>().text.ToString()) > ResurceManager._population)
            {
                peop.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                peop.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        foreach (GameObject pape in paper)
        {
            if (int.Parse(pape.transform.GetChild(0).GetComponent<Text>().text.ToString()) > ResurceManager._cutPaper)
            {
                pape.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                pape.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
