using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCaChua : ObjectMoverManager
{
    private int oldOrderInLayer = 1;
    private int newOrderInLayer = 2;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
        protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        SetOrderInLayer();
    }
    private void SetOrderInLayer()
    {
        spriteRenderer.sortingOrder = newOrderInLayer;
    }
    public void OnMouseUp()
    {
        spriteRenderer.sortingOrder = oldOrderInLayer;
    }
}
