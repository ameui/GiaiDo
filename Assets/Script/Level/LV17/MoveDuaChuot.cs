using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuaChuot : ObjectMoverManager
{
    private bool isTouching;
    public bool meoSadSad;
    public GameObject DuaChuot;
    
    public void Start()
    {
        isTouching = false;  
        meoSadSad = false;
    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        BoxCollider2D duaChuot = DuaChuot.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(duaChuot.bounds.min.x, duaChuot.bounds.max.y);
        Vector2 bottomRight = new Vector2(duaChuot.bounds.max.x, duaChuot.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));

        if (!isTouching && overlapResult != null)
        {
            isTouching = true;
            
        }
    }
    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        if (isTouching)
        {
            meoSadSad = true;
        }
    }


}
