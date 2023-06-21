using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLid : MonoBehaviour
{
    private Insidebox insidebox;
    public GameObject targetObject;
    public bool napmo;

    private void Start()
    {
        insidebox = GameObject.FindObjectOfType<Insidebox>();
        napmo= false;
    }

    private void OnMouseDrag()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;
        insidebox.OnBoxSun();

      
        BoxCollider2D posCollider = GetComponent<BoxCollider2D>();
        BoxCollider2D targetCollider = targetObject.GetComponent<BoxCollider2D>();

        // Kiểm tra xem các hộp có giao nhau hay không
        bool areCollidersIntersecting = posCollider.bounds.Intersects(targetCollider.bounds);

        // Nếu các hộp không giao nhau
        if (!areCollidersIntersecting)
        {      
            napmo= true;
        }
    }

    public bool GetNap()
    {
        return napmo;
    }
}

