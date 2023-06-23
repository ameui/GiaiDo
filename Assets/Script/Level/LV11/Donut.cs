using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
  
    private SpriteRenderer spriteRenderer; 
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
