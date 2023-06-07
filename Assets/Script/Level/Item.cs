/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemId; // ID đại diện cho vật phẩm này
    private LevelManager levelManager;
    private bool isCorrectItem; // Biến kiểm tra xem vật phẩm có đúng yêu cầu không

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();       
    }


    private void Update()
    {
        CheckForTouchOrMouseInput();
    }

    private void CheckForTouchOrMouseInput()
    {
        // Kiểm tra hành động chuột
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnItemClickedOrTouched();
            }
        }

        // Kiểm tra cảm ứng chạm
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnItemClickedOrTouched();
            }
        }
    }

    private void OnItemClickedOrTouched()
    {
        isCorrectItem = levelManager.CheckCorrectItem(itemId);
        if (isCorrectItem)
        {
            levelManager.CompleteLevel();
        }
    }

}
*/