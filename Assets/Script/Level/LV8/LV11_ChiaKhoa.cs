using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV11_ChiaKhoa : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void People()
    {
        spriteRenderer.enabled = true;
    }
}
