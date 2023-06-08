using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV9_HuouMove : MonoBehaviour
{
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public GameObject targetObject; // Đối tượng mà bạn muốn kiểm tra xem BoxCollider của pos có nằm hoàn toàn bên trong hay không
    void Start()
    {      
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
    }
    private void OnMouseDrag()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;

        // Kiểm tra xem BoxCollider của pos có nằm hoàn toàn trong BoxCollider của targetObject hay không
        if (IsColliderInsideAnotherCollider(GetComponent<BoxCollider>(), targetObject.GetComponent<BoxCollider>()))
        {
            levelManager.CompleteLevel();
            tickCompleteLevel.Tick();
        }
    }

    // Hàm này kiểm tra xem colliderA có nằm hoàn toàn trong colliderB hay không
    private bool IsColliderInsideAnotherCollider(BoxCollider colliderA, BoxCollider colliderB)
    {
        // Lấy tất cả các điểm góc của BoxCollider A
        var cornerPoints = new List<Vector3>();

        var extentsA = colliderA.bounds.extents;
        var centerA = colliderA.bounds.center;

        cornerPoints.Add(centerA + new Vector3(extentsA.x, extentsA.y, extentsA.z));
        cornerPoints.Add(centerA + new Vector3(extentsA.x, extentsA.y, -extentsA.z));
        cornerPoints.Add(centerA + new Vector3(extentsA.x, -extentsA.y, extentsA.z));
        cornerPoints.Add(centerA + new Vector3(extentsA.x, -extentsA.y, -extentsA.z));
        cornerPoints.Add(centerA + new Vector3(-extentsA.x, extentsA.y, extentsA.z));
        cornerPoints.Add(centerA + new Vector3(-extentsA.x, extentsA.y, -extentsA.z));
        cornerPoints.Add(centerA + new Vector3(-extentsA.x, -extentsA.y, extentsA.z));
        cornerPoints.Add(centerA + new Vector3(-extentsA.x, -extentsA.y, -extentsA.z));

        // Kiểm tra xem tất cả các điểm góc của BoxCollider A có nằm trong BoxCollider B hay không
        foreach (var point in cornerPoints)
        {
            // Nếu một điểm góc không nằm trong BoxCollider B, trả về false
            if (!colliderB.bounds.Contains(point))
            {
                return false;
            }
        }

        // Nếu tất cả các điểm góc đều nằm trong BoxCollider B, trả về true
        return true;
    }
}
