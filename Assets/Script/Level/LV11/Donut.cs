using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
   
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    private SpriteRenderer spriteRenderer;
    public float pouringAngleThreshold = 180f; // Góc nghiêng tối thiểu để bắt đầu đổ nước
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        
    }

    public void DonutOn()
    {
        spriteRenderer.enabled = true;
    }
    
}
