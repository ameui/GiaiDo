using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChuot : ObjectMoverManager
{
    private int newOrderInLayer = 2;
    private int newOrderInLayer1 = 4;
    private bool isTouching;
    public GameObject Bua;
    public AnimBua animBua;
    public Animchuot animchuot;
    public Sprite normalChuot;
    public Sprite stunChuot;
    private TickCompleteLevel tickCompleteLevel;
    private LevelManager levelManager;
    private bool hasCoroutineStarted = false;
    private SpriteRenderer spriteRenderer;  
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isTouching = false;
    }

   
    protected override void OnMouseDrag()
    {       
       base.OnMouseDrag();
        SetOrderInLayer();
       
            BoxCollider2D bua = Bua.GetComponent<BoxCollider2D>();

            Vector2 topLeft = new Vector2(bua.bounds.min.x, bua.bounds.max.y);
            Vector2 bottomRight = new Vector2(bua.bounds.max.x, bua.bounds.min.y);

            Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));
            if (overlapResult != null)
            {              
            animBua.Toggle();            
            SetOrderInLayer1();           
            StartCoroutine(PerformActionAfterOneSecond(OnCoroutineCompleted));
            isTouching = true;
            hasCoroutineStarted = true;
        }
        
    }
    private void OnCoroutineCompleted()
    {
        if (isTouching && hasCoroutineStarted)
        {
            levelManager.CompleteLevel();
        }
    }
    private void SetOrderInLayer()
    {
        spriteRenderer.sortingOrder = newOrderInLayer;
    }

    private void SetOrderInLayer1()
    {
        spriteRenderer.sortingOrder = newOrderInLayer1;
    }

    private IEnumerator PerformActionAfterOneSecond(Action callback)
    {
        yield return new WaitForSeconds(1.15f); // Chờ 1 giây
        // Cập nhật vị trí của tickCompleteLevel theo vị trí của Chuot
        tickCompleteLevel.transform.position = Bua.transform.position;
        
        ToggleEyes();
        animBua.ToggleOff();
        tickCompleteLevel.Tick();
        if (callback != null)
        {
            callback();
        }
    }
    
    public void ToggleEyes()
    {
        if (spriteRenderer.sprite == normalChuot)
        {
            spriteRenderer.sprite = stunChuot;
        }
        /*else
        {
            spriteRenderer.sprite = closedEyesSprite;
        }*/
    }
}
