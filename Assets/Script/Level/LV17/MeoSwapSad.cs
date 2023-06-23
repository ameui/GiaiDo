using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeoSwapSad : MonoBehaviour
{
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    private bool Check = false;
    public Sprite meoNormal;
    public Sprite meoSad;
    private SpriteRenderer spriteRenderer;
    public MoveDuaChuot moveDuaChuot;

    public void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        tickCompleteLevel = FindObjectOfType<TickCompleteLevel>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(CheckEndLevel()); // Bắt đầu Coroutine CheckEndLevel
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
            Check = true;
        }
        
    }
    private IEnumerator CheckEndLevel()
    {
        while (!Check)
        {
            yield return null; // Chờ đợi cho đến khi khung hình tiếp theo
        }
        EndLevel();
        tickCompleteLevel.Tick();
        levelManager.CompleteLevel();
    }

}
