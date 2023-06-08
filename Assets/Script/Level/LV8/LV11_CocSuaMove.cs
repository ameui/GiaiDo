using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV11_CocSuaMove : MonoBehaviour
{
    public LV11_ChiaKhoa lv11chiakhoa;
    public Sprite normalGlassSprite; // Hình ảnh của cốc nước bình thường
    public Sprite pouringGlassSprite; // Hình ảnh của cốc nước khi đổ
    public float pouringAngleThreshold = 30f; // Góc nghiêng tối thiểu để bắt đầu đổ nước
    private bool hasPoured = false; // Biến kiểm soát việc đã đổ nước hay chưa

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!hasPoured)
        {
            Vector3 acceleration = Input.acceleration;
            float rotationZ = Mathf.Atan2(-acceleration.x, -acceleration.y) * Mathf.Rad2Deg;

            // Nghiêng cốc nước theo gia tốc của thiết bị
            transform.localRotation = Quaternion.Euler(0, 0, rotationZ);

            // Thay đổi hình ảnh của cốc nước nếu góc nghiêng vượt ngưỡng
            if (Mathf.Abs(rotationZ) > pouringAngleThreshold)
            {
                spriteRenderer.sprite = pouringGlassSprite;
                lv11chiakhoa.People();
                hasPoured = true; // Đặt trạng thái đã đổ nước
            }
            else
            {
                spriteRenderer.sprite = normalGlassSprite;
            }
        }
    }
}
