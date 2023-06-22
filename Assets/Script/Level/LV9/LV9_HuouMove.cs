using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LV9_HuouMove : ObjectMoverManager
{
    private bool isTouching;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    private LV9_TulanhZoom tulanhZoom;
    public GameObject targetObject; // Đối tượng mà bạn muốn kiểm tra xem BoxCollider của pos có nằm hoàn toàn bên trong hay không
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        tulanhZoom = GameObject.FindObjectOfType<LV9_TulanhZoom>();
    }
    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        tulanhZoom.OnBoxColider();

        BoxCollider2D huouCollider = GetComponent<BoxCollider2D>();
        BoxCollider2D tulanhCollider = targetObject.GetComponent<BoxCollider2D>();

        if (!isTouching && IsColliderInsideAnother(huouCollider, tulanhCollider))
        {
            isTouching = true;
            tickCompleteLevel.Tick();
            levelManager.CompleteLevel();
        }

    }
    private bool IsColliderInsideAnother(BoxCollider2D colliderA, BoxCollider2D colliderB)
    {
        return colliderA.bounds.min.x > colliderB.bounds.min.x &&
               colliderA.bounds.min.y > colliderB.bounds.min.y &&
               colliderA.bounds.max.x < colliderB.bounds.max.x &&
               colliderA.bounds.max.y < colliderB.bounds.max.y;
    }
}


