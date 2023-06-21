using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public MoveLid moveLid;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    private Donut donut;
    public float pouringAngleThreshold = 160f; // Góc nghiêng tối thiểu để bắt đầu đổ nước
    private bool hasPoured = false; // Biến kiểm soát việc đã đổ nước hay chưa
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        donut= GameObject.FindObjectOfType<Donut>();
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
                if (Mathf.Abs(rotationZ) > pouringAngleThreshold)
                {
                    donut.DonutOn();
                    tickCompleteLevel.Tick();
                    levelManager.CompleteLevel();

                    hasPoured = true;
                }
            }
        }
    }
}
