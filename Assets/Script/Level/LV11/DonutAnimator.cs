using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutAnimator : MonoBehaviour
{
    private Animator animator;
void Start(){
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

public void ToggleDonut()
{
    animator.enabled = true;
}

public void ToggleDonutOff()
{
    animator.enabled = false;
}
}
