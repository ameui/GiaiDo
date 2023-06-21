using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonMove : MonoBehaviour
{
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public LV3_MelonBite melonbite1;
    public GameObject MelonBite;
    public EffEndLevel effEndLevel;
    // Thời gian chờ trước khi thực hiện chức năng (tính bằng giây)
    public float delayTime = 0.5f;

    private bool isTouching;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        isTouching = true;
    }
    public void OnMouseDrag()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
        melonbite1.melonbiteEnabled();

        BoxCollider2D melonbite = MelonBite.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(melonbite.bounds.min.x, melonbite.bounds.max.y);
        Vector2 bottomRight = new Vector2(melonbite.bounds.max.x, melonbite.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));
        // Kiểm tra liệu hai đối tượng có chạm vào nhau hay không
        if (isTouching && overlapResult == null)
        {
            effEndLevel.Show();
            isTouching = false;
            tickCompleteLevel.Tick();
            // Gọi hàm FunctionToCall sau khoảng thời gian delayTime
            Invoke("FunctionToCall", delayTime);
        }
    }

    private void FunctionToCall()
    {
        effEndLevel.Show();
        levelManager.CompleteLevel();
    }
}
