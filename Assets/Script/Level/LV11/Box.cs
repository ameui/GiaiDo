using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public MoveLid moveLid;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    private SpriteRenderer spriteRenderer;
    private Donut donut;
    public float pouringAngleThreshold = 150f; // Góc nghiêng tối thiểu để bắt đầu đổ nước
    private bool hasPoured = false; // Biến kiểm soát việc đã đổ nước hay chưa
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

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

                // Nghiêng cốc nước theo gia tốc của thiết bị
                transform.localRotation = Quaternion.Euler(0, 0, rotationZ);       

                // Thêm điều kiện để hoàn thành cấp độ khi màn hình điện thoại được xoay ngược dọc         
                if (Mathf.Abs(rotationZ) > pouringAngleThreshold)
                {
                    donut.DonutOn();
                    levelManager.CompleteLevel();
                    tickCompleteLevel.Tick();
                    hasPoured = true;
                }
            }
        }
    }
}
