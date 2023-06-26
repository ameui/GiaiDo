using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class MoveDiem : ObjectMoverManager
{
    public GameObject ViTriDung;
    private bool isTouching;

    private TickCompleteLevel tickCompleteLevel;
    public void Start()
    {
        isTouching = false;
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
    }
    protected override void OnMouseDrag()
    {
       base.OnMouseDrag();
        BoxCollider2D viTriDung = ViTriDung.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(viTriDung.bounds.min.x, viTriDung.bounds.max.y);
        Vector2 bottomRight = new Vector2(viTriDung.bounds.max.x, viTriDung.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));
        if (overlapResult != null)
        {
           
            if (!isTouching)
            {
                isTouching = true;
               /* tickCompleteLevel.Tick();
                GameManager.Instance.LevelComplete();*/

            }

        }
    }
    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        BoxCollider2D viTriDung = ViTriDung.GetComponent<BoxCollider2D>();
        if (isTouching)
        {
            transform.position = viTriDung.bounds.center;
            tickCompleteLevel.Tick();
            GameManager.Instance.LevelComplete();
        }
    }
}
