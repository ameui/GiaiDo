using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV8_People : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
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
