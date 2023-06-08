using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR;

public class LV7_NestCheck : MonoBehaviour
{
    public GameObject Hen;
    public GameObject Nest;
    public GameObject ClickableObject; // Đối tượng mà người dùng cần nhấp chuột vào
    private LevelManager levelManager;
    private bool isTouching;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isTouching = true;
    }

    private void Update()
    {
        BoxCollider2D hen = Hen.GetComponent<BoxCollider2D>();
        BoxCollider2D nest = Nest.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(nest.bounds.min.x, nest.bounds.max.y);
        Vector2 bottomRight = new Vector2(nest.bounds.max.x, nest.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));

        if (isTouching && overlapResult == null)
        {
            isTouching = false;
        }
        else if (!isTouching && overlapResult != null)
        {
            isTouching = true;
        }
    
}

    // Hàm gọi khi nhấp chuột vào đối tượng này
    public void OnMouseDown()
    {
        if (!isTouching) // Nếu hai hộp không còn tiếp xúc với nhau
        {
            levelManager.CompleteLevel();
        }
    }
}
