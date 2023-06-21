using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class lV1_Watermelon : MonoBehaviour
{
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public LV1_Mandarin mandarin1;
    public GameObject Mandarin;
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
        mandarin1.madarinEnabled();
        BoxCollider2D mandarin = Mandarin.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(mandarin.bounds.min.x, mandarin.bounds.max.y);
        Vector2 bottomRight = new Vector2(mandarin.bounds.max.x, mandarin.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));
        // Kiểm tra liệu hai đối tượng có chạm vào nhau hay không
        if (isTouching && overlapResult == null)
        {
            isTouching = false;
            tickCompleteLevel.Tick();
            levelManager.CompleteLevel();           
        }
    }  
}



