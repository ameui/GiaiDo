using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LV9_HuouMove : MonoBehaviour
{
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
    private void OnMouseDrag()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;
        tulanhZoom.OnBoxColider();

        // Kiểm tra xem BoxCollider của pos có nằm hoàn toàn trong BoxCollider của targetObject hay không
        BoxCollider2D posCollider = GetComponent<BoxCollider2D>();
        BoxCollider2D targetCollider = targetObject.GetComponent<BoxCollider2D>();
        if (posCollider.bounds.min.x >= targetCollider.bounds.min.x &&
            posCollider.bounds.min.y >= targetCollider.bounds.min.y &&
            posCollider.bounds.max.x <= targetCollider.bounds.max.x &&
            posCollider.bounds.max.y <= targetCollider.bounds.max.y)
        {
            levelManager.CompleteLevel();
            tickCompleteLevel.Tick();
        }
        
    }

    // Hàm này kiểm tra xem colliderA có nằm hoàn toàn trong colliderB hay không

}


