using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMao : MonoBehaviour
{
    private ObjectMoverManager objectMover;
    private Ga ga;
    public GameObject targetObject; // Đối tượng mà bạn muốn kiểm tra xem BoxCollider của pos có nằm hoàn toàn bên trong hay không
    private bool maoga;
    private void Start()
    {
        ga = GameObject.FindObjectOfType<Ga>();
        objectMover = GameObject.FindObjectOfType<ObjectMoverManager>();
        maoga = false;
    }

    private void OnMouseDrag()
    {
        Debug.Log("Khong di chuyển mào");
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;
        ga.OnBoxGa();
        // Kiểm tra xem BoxCollider của pos có nằm hoàn toàn trong BoxCollider của targetObject hay không
        BoxCollider2D posCollider = GetComponent<BoxCollider2D>();
        BoxCollider2D targetCollider = targetObject.GetComponent<BoxCollider2D>();

        // Kiểm tra xem các hộp có giao nhau hay không
        bool areCollidersIntersecting = posCollider.bounds.Intersects(targetCollider.bounds);

        // Nếu các hộp không giao nhau
        if (!areCollidersIntersecting)
        {
            maoga = true;
        }


    }

    private void OnMouseUp()
    {
        
        
              
    }

    public bool GetMaoGa()
    {
        return maoga;
    }
}
