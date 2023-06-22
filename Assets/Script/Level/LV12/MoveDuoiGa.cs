using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuoiGa : ObjectMoverManager
{

    private Ga ga;
    public GameObject targetObject; // Đối tượng mà bạn muốn kiểm tra xem BoxCollider của pos có nằm hoàn toàn bên trong hay không
    private bool duoiga;
    private Egg egg;
    private void Start()
    {
        ga = GameObject.FindObjectOfType<Ga>();
        duoiga = false;
        egg = GameObject.FindObjectOfType<Egg>();
    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
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

        egg.showEgg();

    }
    public bool GetDuoiGa()
    {
        return duoiga;
    }
}
