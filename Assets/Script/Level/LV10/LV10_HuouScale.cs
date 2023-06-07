using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV10_HuouScale : MonoBehaviour
{
    private Camera mainCamera;
    private Collider2D neckCollider;
    private Vector3 initialNeckScale;
    private bool isScaling = false;
    private LevelManager levelManager;

    private void Start()
    {
        mainCamera = Camera.main;
        neckCollider = GetComponent<Collider2D>();
        initialNeckScale = transform.localScale;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (neckCollider.OverlapPoint(touchPosition))
                {
                    isScaling = true;                  
                }
            }
            else if (touch.phase == TouchPhase.Moved && isScaling)
            {
                // Thay đổi scale dựa trên vị trí chạm
                float newScaleY = Mathf.Clamp(touchPosition.y, initialNeckScale.y, initialNeckScale.y * 2);
                transform.localScale = new Vector3(initialNeckScale.x, newScaleY, initialNeckScale.z);
                levelManager.CompleteLevel();
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isScaling = false;
            }
        }
    }
}
