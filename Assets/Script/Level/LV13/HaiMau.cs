using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HaiMau : MonoBehaviour
{
   
    private int shakeCount = 0; // Số lần lắc hiện tại
    private float shakeThreshold = 2f; // Ngưỡng lắc để xác định lắc
    private float timeBetweenShakes = 0.5f; // Thời gian giữa các lần lắc
    private float lastShakeTime; // Thời gian lắc cuối cùng
    private Vector3 lastAcceleration; // Gia tốc trước đó
    public Sprite normalOK; // Hình ảnh của cốc nước bình thường
    public Sprite pouringOK; // Hình ảnh của cốc nước khi đổ
    private SpriteRenderer spriteRenderer;
    private TickCompleteLevel tickCompleteLevel;
    private Vector3 old;
    void Start()
    {
        lastAcceleration = Vector3.zero;
        lastShakeTime = Time.time;
        spriteRenderer = GetComponent<SpriteRenderer>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        old = transform.position;
    }

    void Update()
    {
        
        CheckShake();
    }

    private void CheckShake()
    {
        Vector3 currentAcceleration = Input.acceleration;
        float accelerationDifference = (currentAcceleration - lastAcceleration).magnitude;
        if (accelerationDifference >= shakeThreshold && Time.time - lastShakeTime >= timeBetweenShakes)
        {
            shakeCount++;
            lastShakeTime = Time.time;
            if (shakeCount >= 3)
            {
                ToggleEyes();
                transform.position = old;
                tickCompleteLevel.Tick();
                GameManager.Instance.LevelComplete();
               
                /* spriteRenderer.sprite = pouringOK;*/
                /*shakeCount = 0;*/
            }
        }
        /* else if (Time.time - lastShakeTime >= timeBetweenShakes)
         {
             shakeCount = 0;
         }*/
        float rotationZ = Mathf.Atan2(-currentAcceleration.x, -currentAcceleration.y) * Mathf.Rad2Deg;
        float rotationThreshold = 20f; // Ngưỡng lọc sự thay đổi góc quay
        // Kiểm tra xem sự thay đổi góc quay có lớn hơn ngưỡng không
        if (Mathf.Abs(rotationZ) > 30)
        {
            rotationZ = Mathf.Sign(rotationZ) * 30;
        }
        if (Mathf.Abs(rotationZ - transform.localEulerAngles.z) > rotationThreshold)
        {
            transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
        }
        
        
        lastAcceleration = currentAcceleration;
    }

    public void ToggleEyes()
    {
        if (spriteRenderer.sprite == normalOK)
        {
            spriteRenderer.sprite = pouringOK;
        }
    }

    }
