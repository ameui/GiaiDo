using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LV8_Earth : MonoBehaviour
{
    public LV8_ButtonUp lv8buttonup;
    public LV8_People lv8people;
    public Sprite EarthHappySprite; // Sprite của trái đất bình thường
    public Sprite EarthSadSprite; // Sprite của trái đất nổ 
    private SpriteRenderer spriteRenderer; // Để truy cập Sprite Renderer của GameObject
    private LevelManager levelManager;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    public void ToggleEyes()
    {
        if (spriteRenderer.sprite == EarthHappySprite)
        {
            spriteRenderer.sprite = EarthSadSprite;
        }
    }

    void Update()
    {
        if (lv8buttonup.buttonStatus)
        {
            ToggleEyes();
            levelManager.LoseLevel();
        }

        if (lv8buttonup.buttonStatus1)
        {
            lv8people.People();
            levelManager.CompleteLevel();
        }

    }

}
