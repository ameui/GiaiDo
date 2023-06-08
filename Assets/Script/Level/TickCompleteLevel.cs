using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickCompleteLevel : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public void Start()
    {       
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void Tick()
    {
        spriteRenderer.enabled = true;
    }
}
