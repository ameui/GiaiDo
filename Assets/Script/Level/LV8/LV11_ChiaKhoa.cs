using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV11_ChiaKhoa : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;

    public void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void People()
    {
        spriteRenderer.enabled = true;
        tickCompleteLevel.Tick();
        levelManager.CompleteLevel();
    }
}
