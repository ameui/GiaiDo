using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{

    /*  private void OnMouseDrag()
      {
          var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          pos.z = transform.position.z;
          transform.position = pos;   
      }*/

    private Vector3 offset;

    private void OnMouseDown()
    {
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        offset = transform.position - mouseScreenPosition;
    }

    private void OnMouseDrag()
    {
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        transform.position = mouseScreenPosition + offset;
    }
}
