using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class lV1_Watermelon : ObjectMoverManager
{
    private TickCompleteLevel tickCompleteLevel;
    public LV1_Mandarin mandarin1;
    public GameObject Mandarin;
    private bool isTouching;

    private void Start()
    {
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        isTouching = true; 
        
    }
    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        mandarin1.madarinEnabled();
        BoxCollider2D mandarin = Mandarin.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(mandarin.bounds.min.x, mandarin.bounds.max.y);
        Vector2 bottomRight = new Vector2(mandarin.bounds.max.x, mandarin.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));
        // Kiểm tra liệu hai đối tượng có chạm vào nhau hay không
        if (isTouching && overlapResult == null)
        {
            isTouching = false;      
        }
    }  
    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        if (!isTouching)
        {        
            tickCompleteLevel.Tick();
            GameManager.Instance.LevelComplete();
        }
    }
}



