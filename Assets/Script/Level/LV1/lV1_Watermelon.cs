using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class lV1_Watermelon : MonoBehaviour
{
    


   
    

//     private void HandleTouchDrag()
// {
//     // Kiểm tra liệu có cảm ứng nào đang diễn ra hay không
//     if (Input.touchCount > 0)
//     {
//         Touch touch = Input.GetTouch(0);

//         // Kiểm tra xem cảm ứng đó có phải là di chuyển (kéo) hay không
//         if (touch.phase == TouchPhase.Moved)
//         {
//             // Chuyển đổi tọa độ cảm ứng thành tọa độ thế giới
//             Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
//             touchPosition.z = transform.position.z;

//             // Kiểm tra xem cảm ứng có diễn ra trên đối tượng này hay không
//             Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
//             if (touchedCollider != null && touchedCollider.transform == transform)
//             {
//                 // Di chuyển đối tượng theo tọa độ cảm ứng
//                 transform.position = touchPosition;
//             }
//         }
//     }
// }


private bool isDragging;

    private void Update()
    {
        if (isDragging)
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z;
            transform.position = pos;
        }
    }

    private void OnMouseDown()
    {
        // Tạo một tia từ vị trí chuột trên màn hình đến thế giới 2D
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        // Kiểm tra xem tia có chạm vào Watermelon không
        if (hit.collider != null && hit.collider.gameObject == this.gameObject)
        {
            isDragging = true;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}

// private void OnTouchDrag()
// {
//     Debug.Log("abc");
//     var pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
//     pos.z = transform.position.z;
//     transform.position = pos;
// }

 
