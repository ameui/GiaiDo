using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animchuot : MonoBehaviour
{
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.GetComponent<Animator>().enabled = false;
    }

    public void ToggleChuot()
    {
        animator.GetComponent<Animator>().enabled = enabled;
    }

    public void ToggleChuotOff()
    {
        animator.GetComponent<Animator>().enabled = false;
    }
}
