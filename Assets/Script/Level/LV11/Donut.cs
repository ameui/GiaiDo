using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public MoveLid moveLid;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    private SpriteRenderer spriteRenderer;
    public float pouringAngleThreshold = 180f; // Góc nghiêng tối thiểu để bắt đầu đổ nước
    private bool hasPoured = false; // Biến kiểm soát việc đã đổ nước hay chưa
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
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
              
                    spriteRenderer.enabled = true;
                    levelManager.CompleteLevel();
                    tickCompleteLevel.Tick();
                
            }
        }
    }
}
