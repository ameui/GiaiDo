using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV11_ChiaKhoa : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public float delayTime = 0.5f;
    public EffEndLevel effEndLevel;

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
        effEndLevel.Show();
        tickCompleteLevel.Tick();
        Invoke("FunctionToCall", delayTime);
    }
    private void FunctionToCall()
    {
        levelManager.CompleteLevel();
    }
}
