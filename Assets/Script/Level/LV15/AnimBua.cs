using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBua : MonoBehaviour
{
    private Animator animator;
 

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.GetComponent<Animator>().enabled = false;
    }

    public void Toggle()
    {
        animator.GetComponent<Animator>().enabled = enabled;
    }

    public void ToggleOff()
    {
        animator.GetComponent<Animator>().enabled = false;
    }
}
