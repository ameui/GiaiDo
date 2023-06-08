using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public Sprite normalIceSprite; // Hình ảnh của ice bình thường
    public Sprite pouringIceSprite; // Hình ảnh của ice khi tan
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DaTan()
    {
        spriteRenderer.sprite = pouringIceSprite;
    }
}
