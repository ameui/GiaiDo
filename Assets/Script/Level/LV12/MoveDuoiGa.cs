using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuoiGa : MonoBehaviour
{

    private ObjectMoverManager objectMover;
    private Ga ga;
    public GameObject targetObject; // Đối tượng mà bạn muốn kiểm tra xem BoxCollider của pos có nằm hoàn toàn bên trong hay không
    private bool duoiga;
    private void Start()
    {
        ga = GameObject.FindObjectOfType<Ga>();
        objectMover = GameObject.FindObjectOfType<ObjectMoverManager>();
        duoiga = false;
    }

    private void OnMouseDrag()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;
        ga.OnBoxGa();
        BoxCollider2D posCollider = GetComponent<BoxCollider2D>();
        BoxCollider2D targetCollider = targetObject.GetComponent<BoxCollider2D>();

        // Kiểm tra xem các hộp có giao nhau hay không
        bool areCollidersIntersecting = posCollider.bounds.Intersects(targetCollider.bounds);

        // Nếu các hộp không giao nhau
        if (!areCollidersIntersecting)
        {
            duoiga = true;
        }


    }

    private void OnMouseUp()
    {
        
        
        
    }

    public bool GetDuoiGa()
    {
        return duoiga;
    }
}
