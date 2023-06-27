using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChuot : ObjectMoverManager
{
    private bool isTouching;
    public GameObject Bua;
    public AnimBua animBua;
    public Animchuot animchuot;
    public Sprite normalChuot;
    public Sprite stunChuot;
    private TickCompleteLevel tickCompleteLevel;
    private LevelManager levelManager;
    private bool hasCoroutineStarted = false;
    private void Start()
    {
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isTouching = false;
      /*  StartCoroutine(CheckEndLevel());*/
    }
    private void Update()
    {
        BoxCollider2D bua = Bua.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(bua.bounds.min.x, bua.bounds.max.y);
        Vector2 bottomRight = new Vector2(bua.bounds.max.x, bua.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));
        if (overlapResult != null)
        {
            animBua.Toggle();
            isTouching = true;
            hasCoroutineStarted = true;
            tickCompleteLevel.transform.position = Bua.transform.position;
            Debug.Log("true");
        }
        else
        {
            isTouching = false;
            Debug.Log("fasle");
        }
    }
    protected override void OnMouseDrag()
    {       
       base.OnMouseDrag();

        animchuot.ToggleChuotOff1();
            
        
    }
    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        spriteRenderer.sortingOrder = 4;
        if (isTouching && hasCoroutineStarted)
        {
            animBua.ToggleOff();
            ToggleEyes();
            tickCompleteLevel.Tick();
            LevelManager.Instance.CompleteLevel();
        }
           
    }
    /*private IEnumerator CheckEndLevel()
    {

            while (!isTouching && !hasCoroutineStarted)
            {
            yield return null; // Chờ đợi cho đến khi khung hình tiếp theo
        }
           
        animBua.ToggleOff();

        ToggleEyes();
       
        tickCompleteLevel.Tick();
        LevelManager.Instance.CompleteLevel();

    }*/
/*    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        s
    }*/

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
