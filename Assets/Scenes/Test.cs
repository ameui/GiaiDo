using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnMouseDrag()
{
    Debug.Log("abc");
    var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    pos.z = transform.position.z;
    transform.position = pos;

}
}
