using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBua : MonoBehaviour
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

    private void OnMouseDrag()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        pos.z = transform.position.z;
        transform.position = pos;
        isClickBua = true;
    }

    private void OnMouseUp()
    {
        isClickBua = false;
    }

}
