using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation_building : MonoBehaviour
{
    public Toggle button;
    public Animator animator;

    public void button_script()
    {
        if (button.isOn)
        {
            animator.SetBool("Open", true);
        }
        else
            animator.SetBool("Open", false);
    }
}
