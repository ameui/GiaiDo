using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animchuot : MonoBehaviour
{
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    public void ToggleChuot()
    {
        animator.enabled = true;
        animator.SetBool("on", false);

    }

    public void ToggleChuotOff()
    {
        animator.SetBool("on", true);
    }

    public void ToggleChuotOff1()
    {
        animator.enabled = false;

    }
}
