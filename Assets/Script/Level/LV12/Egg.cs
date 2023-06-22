using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private MoveDuoiGa moveDuoiGa;
    private MoveMao moveMao;
    private SpriteRenderer spriteRenderer;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        moveMao = GameObject.FindObjectOfType<MoveMao>();
        moveDuoiGa = GameObject.FindObjectOfType<MoveDuoiGa>();
    }

    // Update is called once per frame
    public void showEgg()
    {
        if(moveMao.GetMaoGa() && moveDuoiGa.GetDuoiGa())
        {
            spriteRenderer.enabled = true;
            tickCompleteLevel.Tick();
            levelManager.CompleteLevel();
            
        }
    }
}
