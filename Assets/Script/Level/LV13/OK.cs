using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Vector2 pos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void ChangeObject()
    {
        spriteRenderer.enabled = true;
    }
}
