using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : ObjectMoverManager
{
    private FireMesh fireMesh;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    private Transform tickTransform; // Thêm biến tickTransform để lưu trữ vị trí của đối tượng TickCompleteLevel
    private void Start()
    {
        fireMesh = GameObject.FindObjectOfType<FireMesh>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();

        // Tìm đối tượng TickCompleteLevel trong đống lửa hiện tại

        if (tickCompleteLevel != null)
        {
            tickTransform = tickCompleteLevel.transform;
        }
    }
    /*private Vector3 offset;*/

    /*    private void OnMouseDown()
        {
            Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            offset = transform.position - mouseScreenPosition;
        }*/

    /*    private void OnMouseDrag()
        {
            Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            transform.position = mouseScreenPosition + offset;
        }*/
    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        if (fireMesh.EndLevel)
        {
          
                if (tickTransform != null)
                {
                    tickTransform.position = transform.position; // Di chuyển đối tượng TickCompleteLevel đến vị trí của đống lửa cuối cùng
                }
                /*     TickCompleteLevel tickCompleteLevel = GetComponentInChildren<TickCompleteLevel>();*/
                if (tickCompleteLevel != null)
                {
                    tickCompleteLevel.Tick();
                }
                /*sMerged = true;*/
                levelManager.CompleteLevel();
            
        }
    }
}
