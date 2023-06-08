using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV7HenMove : MonoBehaviour
{
    private void OnMouseDrag()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;
    }
}
