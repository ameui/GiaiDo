using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV11_ChiaKhoa : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void People()
    {
        spriteRenderer.enabled = true;
        levelManager.CompleteLevel();
    }
}
