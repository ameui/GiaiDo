using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlSlep : MonoBehaviour
{
    private LevelManager levelManager;
    public Sprite closedEyesSprite; // Sprite của con cú với mắt nhắm
    public Sprite openEyesSprite; // Sprite của con cú với mắt mở
    public SunMove sunMove; // Tham chiếu đến đối tượng SunMove
    private SpriteRenderer spriteRenderer; // Để truy cập Sprite Renderer của GameObject
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
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
    // Update is called once per frame



    void Update()
    {
        if (sunMove.sunHight)
        {
            ToggleEyes();
            levelManager.CompleteLevel();
        }
    }

}
