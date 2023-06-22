using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlSlep : MonoBehaviour
{
    
    public Sprite closedEyesSprite; // Sprite của con cú với mắt nhắm
    public Sprite openEyesSprite; // Sprite của con cú với mắt mở
    public SunMove sunMove; // Tham chiếu đến đối tượng SunMove
    private SpriteRenderer spriteRenderer; // Để truy cập Sprite Renderer của GameObject
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    public void ToggleEyes()
    {
        if (spriteRenderer.sprite == closedEyesSprite)
        {
            spriteRenderer.sprite = openEyesSprite;
        }
        /*else
        {
            spriteRenderer.sprite = closedEyesSprite;
        }*/
    }
   
}
