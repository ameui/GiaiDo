using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV8_ButtonUp : MonoBehaviour
{
    public Sprite buttonEyesSprite; // Sprite của button bình thường
    public Sprite buttonUpEyesSprite; // Sprite của button up
    private SpriteRenderer spriteRenderer; // Để truy cập Sprite Renderer của GameObject
    public bool buttonStatus = false;
    public bool buttonStatus1 = false;

    private Collider2D col2D;
    private float timeCnt;
    private float pressStartTime;

    void Start()
    {
        col2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ToggleEyes()
    {
        if (spriteRenderer.sprite == buttonEyesSprite)
        {
            spriteRenderer.sprite = buttonUpEyesSprite;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (col2D == Physics2D.OverlapPoint(mousePos))
            {
                pressStartTime = Time.time;
            }
        }

/*        if (Input.GetMouseButton(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (col2D == Physics2D.OverlapPoint(mousePos))
            {
                timeCnt += Time.deltaTime;
                if (timeCnt < 1)
                {
                    
                }
                if (timeCnt >= 5)
                {
                    
                }
            }
        }*/

        if (Input.GetMouseButtonUp(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (col2D == Physics2D.OverlapPoint(mousePos))
            {
                if (Time.time - pressStartTime < 1)
                {
                    ToggleEyes();
                    buttonStatus = true;
                }
                if(Time.time - pressStartTime >= 5)
                {
                    ToggleEyes();
                    buttonStatus1 = true;
                }
            }
        }
    }
}
