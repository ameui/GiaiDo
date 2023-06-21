using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AladinSwap : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public Sprite Aladin_01;
    public Sprite Aladin_03;
    public Sprite Aladin_02;

    public List<MoveItem> moveItems;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
    }

    public void ToggleEyesSai()
    {
        if (spriteRenderer.sprite == Aladin_01)
        {
            spriteRenderer.sprite = Aladin_03;
        }
              
    }
    public void ToggleEyesDung()
    {
        Debug.Log("xyz");
        if (spriteRenderer.sprite == Aladin_01 || spriteRenderer.sprite == Aladin_03)
        {
            spriteRenderer.sprite = Aladin_02;
        }
        
    }

    public void Toggle()
    {
        spriteRenderer.sprite = Aladin_01;
    }

    private void Update()
    {
        foreach (MoveItem moveItem in moveItems)
        {// Duyệt qua tất cả các MoveItem trong danh sách
            if (moveItem.AladinChet)
            {
                ToggleEyesDung();
                levelManager.CompleteLevel();
                tickCompleteLevel.Tick();
            }else if (moveItem.AladinSo)
            {
                ToggleEyesSai();
            }else
            {
                Toggle();
            }
            
            /*else
            {
                Toggle();
            }*/
        }
    }
}
