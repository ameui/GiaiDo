using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoverManager : MonoBehaviour
{
    protected virtual void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }
}
