using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HaiMau : MonoBehaviour
{
   
    private int currentIndex = 0; // Đối tượng hiện tại
    private int shakeCount = 0; // Số lần lắc hiện tại
    private float shakeThreshold = 2f; // Ngưỡng lắc để xác định lắc
    private float timeBetweenShakes = 0.5f; // Thời gian giữa các lần lắc
    private float lastShakeTime; // Thời gian lắc cuối cùng
    private Vector3 lastAcceleration; // Gia tốc trước đó
    public Sprite normalOK; // Hình ảnh của cốc nước bình thường
    public Sprite pouringOK; // Hình ảnh của cốc nước khi đổ
    private SpriteRenderer spriteRenderer;
    public Text text;
    public Text text1;
    public OK ok;
    private LevelManager levelManager;

    void Start()
    {
        lastAcceleration = Vector3.zero;
        lastShakeTime = Time.time;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ok = GameObject.FindObjectOfType<OK>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        CheckShake();
    }

    private void CheckShake()
    {
        Vector3 currentAcceleration = Input.acceleration;
        float accelerationDifference = (currentAcceleration - lastAcceleration).magnitude;
        text.text = "accelerationDifference" + accelerationDifference;
        if (accelerationDifference >= shakeThreshold && Time.time - lastShakeTime >= timeBetweenShakes)
        {
            shakeCount++;
            lastShakeTime = Time.time;
            text1.text = "shakeCount" + shakeCount;
            if (shakeCount >= 3)
            {
                ok.ChangeObject();
                levelManager.CompleteLevel();
               /* spriteRenderer.sprite = pouringOK;*/
                /*shakeCount = 0;*/
            }
        }
       /* else if (Time.time - lastShakeTime >= timeBetweenShakes)
        {
            shakeCount = 0;
        }*/

        lastAcceleration = currentAcceleration;
    }
   
}
