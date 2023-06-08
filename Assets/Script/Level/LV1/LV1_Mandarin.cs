using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1_Mandarin : MonoBehaviour
{
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public GameObject Watermelon;
    public GameObject Mandarin;

    private bool isTouching;

     private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        isTouching = true;
    }

    private void Update()
    {
        BoxCollider2D watermelon = Watermelon.GetComponent<BoxCollider2D>();
        BoxCollider2D mandarin = Mandarin.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(watermelon.bounds.min.x, watermelon.bounds.max.y);
        Vector2 bottomRight = new Vector2(watermelon.bounds.max.x, watermelon.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));
        // Kiểm tra liệu hai đối tượng có chạm vào nhau hay không
        if (isTouching && overlapResult == null)
        {
            isTouching = false;
            tickCompleteLevel.Tick();
            levelManager.CompleteLevel();
            
        }
        else if (!isTouching && overlapResult != null)
        {
            isTouching = true;
        }
    
}

   
}

