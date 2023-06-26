using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public MoveLid moveLid;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    private Donut donut;
    private DonutAnimator donutAnimator;
    public float pouringAngleThreshold = 80f; // Góc nghiêng tối thiểu để bắt đầu rơi bánh
    private bool hasPoured = false; // Biến kiểm soát việc đã đổ nước hay chưa
    private bool Check = false;
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        donut= GameObject.FindObjectOfType<Donut>();
        donutAnimator = GameObject.FindObjectOfType<DonutAnimator>();
        StartCoroutine(CheckEndLevel()); // Bắt đầu Coroutine CheckEndLevel
    }

    private void Update()
    {
        if (moveLid.GetNap())
        {
            if (!hasPoured)
            {
                Vector3 acceleration = Input.acceleration;
                float rotationZ = Mathf.Atan2(-acceleration.x, -acceleration.y) * Mathf.Rad2Deg;

                // Nghiêng thùng giấy theo gia tốc của thiết bị
                transform.localRotation = Quaternion.Euler(0, 0, rotationZ);

                // Thêm điều kiện để hoàn thành cấp độ khi màn hình điện thoại được xoay ngược dọc
                if (rotationZ > pouringAngleThreshold)
                {
                    Check = true;
                }
            }
        }
    }
    private IEnumerator CheckEndLevel()
    {
        while (!Check)
        {
            yield return null; // Chờ đợi cho đến khi khung hình tiếp theo
        }
        donut.DonutOn();
        donutAnimator.ToggleDonut();
        tickCompleteLevel.Tick();
        levelManager.CompleteLevel();
        hasPoured = true;
    }
}
