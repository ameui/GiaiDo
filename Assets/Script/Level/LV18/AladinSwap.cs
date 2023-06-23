using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AladinSwap : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private TickCompleteLevel tickCompleteLevel;
    public Sprite Aladin_01;
    public Sprite Aladin_03;
    public Sprite Aladin_02;
    private bool Check = false;
    public List<MoveItem> moveItems;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        StartCoroutine(CheckEndLevel()); // Bắt đầu Coroutine CheckEndLevel
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
        bool allItemsNeutral = true;
        bool anyItemAladinSo = false;
        bool anyItemAladinChet = false;

        foreach (MoveItem moveItem in moveItems)
        {
            if (moveItem.AladinChet)
            {
                anyItemAladinChet = true;
            }
            else if (moveItem.AladinSo)
            {
                anyItemAladinSo = true;
            }
            else
            {
                allItemsNeutral &= true;
            }
        }

        if (anyItemAladinChet)
        {
            ToggleEyesDung();
            if (!Check)
            {               
                Check = true;
            }
        }
        else if (anyItemAladinSo)
        {
            ToggleEyesSai();
        }
        else if (allItemsNeutral)
        {
            Toggle();
        }
    }
    private IEnumerator CheckEndLevel()
    {
        while (!Check)
        {
            yield return null; // Chờ đợi cho đến khi khung hình tiếp theo
        }
        tickCompleteLevel.Tick();
        LevelManager.Instance.CompleteLevel();
    }
}
