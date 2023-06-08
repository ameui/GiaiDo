using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV9_TulanhZoom : MonoBehaviour
{
    private BoxCollider2D col2D;
    public float zoomFactor = 1.5f; // Độ phóng đại của đối tượng
    private int scaleCounter = 0; // Biến đếm số lần thay đổi kích thước
    private int maxScaleTimes = 2; // Số lần scale tối đa
    private float initialTouchDistance; // Khoảng cách ban đầu giữa hai ngón tay

    private void Start()
    {
        col2D = GetComponent<BoxCollider2D>();
        col2D.enabled = false;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialTouchDistance = Vector2.Distance(touch1.position, touch2.position);
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentTouchDistance = Vector2.Distance(touch1.position, touch2.position);
                float touchDistanceDelta = currentTouchDistance - initialTouchDistance;

                if (Mathf.Abs(touchDistanceDelta) > 10) // Thay đổi giá trị này để kiểm soát độ nhạy khi zoom
                {
                    if (scaleCounter < maxScaleTimes)
                    {
                        ZoomIn();
                        scaleCounter++;
                    }
                }
            }
        }
    }

    public void ZoomIn()
    {
        Debug.Log(transform.localScale);
        transform.localScale *= zoomFactor;
    }

    public void OnBoxColider()
    {
        col2D.enabled = true;
    }
}
