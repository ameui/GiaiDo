using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeoSwapSad : MonoBehaviour
{
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public Sprite meoNormal;
    public Sprite meoSad;
    private SpriteRenderer spriteRenderer;
    public MoveDuaChuot moveDuaChuot;

    public void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        tickCompleteLevel = FindObjectOfType<TickCompleteLevel>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void EndLevel()
    {
        if (spriteRenderer.sprite == meoNormal)
        {
            spriteRenderer.sprite = meoSad;
        }
        /*else
        {
            spriteRenderer.sprite = meoNormal;
        }*/
    }
    public void Update()
    {
        if (moveDuaChuot.meoSadSad)
        {
            EndLevel();
            tickCompleteLevel.Tick();
            levelManager.CompleteLevel();
            
        }
        
    }
    
}
