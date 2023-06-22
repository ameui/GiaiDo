using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMoiThu : ObjectMoverManager
{
    public GameObject Insidebox;
    private bool isTouching;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;

    private void Start()
    {
        isTouching = false;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();      
    }

    protected override void OnMouseDrag()
    {   
        base.OnMouseDrag();

        BoxCollider2D insidebox = Insidebox.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(insidebox.bounds.min.x, insidebox.bounds.max.y);
        Vector2 bottomRight = new Vector2(insidebox.bounds.max.x, insidebox.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));

        if (!isTouching && overlapResult != null)
        {
            isTouching = true;
            tickCompleteLevel.Tick();
            levelManager.CompleteLevel();

        }
    }
}
