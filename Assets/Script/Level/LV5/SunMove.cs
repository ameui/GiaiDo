using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour
{
    public bool sunHight;
    public GameObject Tree;
    private bool isTouching;
    private void Start()
    {
        isTouching = false;
        sunHight = false;
    }

    private void OnMouseDrag()
    {      
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;

        BoxCollider2D tree = Tree.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(tree.bounds.min.x, tree.bounds.max.y);
        Vector2 bottomRight = new Vector2(tree.bounds.max.x, tree.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));

        if (overlapResult != null)
        {
            // Di chuyển Sun vào giữa Collider của Tree
            transform.position = tree.bounds.center;

            if (!isTouching)
            {
                isTouching = true;
                sunHight = true;
            }
        }
    }
}
