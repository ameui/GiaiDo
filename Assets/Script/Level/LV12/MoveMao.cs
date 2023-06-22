using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMao : ObjectMoverManager
{
    private Ga ga;
    private Egg egg;
    public GameObject targetObject; // Đối tượng mà bạn muốn kiểm tra xem BoxCollider của pos có nằm hoàn toàn bên trong hay không
    private bool maoga;
    private void Start()
    {
        ga = GameObject.FindObjectOfType<Ga>();
        egg = GameObject.FindObjectOfType<Egg>();
        maoga = false;
    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
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

        egg.showEgg();
    }

    public bool GetMaoGa()
    {
        return maoga;
    }
}
