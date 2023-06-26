using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : ObjectMoverManager
{
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public OwlSlep owlSlep;
    public bool sunHight;
    public GameObject Tree;
    private bool isTouching;
    private void Start()
    {
        isTouching = false;
        sunHight = false;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        owlSlep = GameObject.FindObjectOfType<OwlSlep>();
    }

    protected override void OnMouseDrag()
    {      
        base.OnMouseDrag();
  
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
                    owlSlep.ToggleEyes();
                    tickCompleteLevel.Tick();
                    GameManager.Instance.LevelComplete();
                }
            }
              
    }
    protected override void OnMouseUp()
    {
        base.OnMouseUp();
    }
}
