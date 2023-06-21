using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCaChua : MonoBehaviour
{
    private int oldOrderInLayer = 1;
    private int newOrderInLayer = 2;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
        public void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
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
