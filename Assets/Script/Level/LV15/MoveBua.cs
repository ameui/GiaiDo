using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBua : ObjectMoverManager
{
    private bool isTouching;
    public GameObject Bua;
    public Animchuot animChuot;

    bool isClickBua = false;

    private void Update()
    {
        if (isClickBua)
        {
            animChuot.ToggleChuot();
        }
        else
        {
            animChuot.ToggleChuotOff();
        }
    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        isClickBua = true;
    }

    private void OnMouseUp()
    {
        isClickBua = false;
    }

}
