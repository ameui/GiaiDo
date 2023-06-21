using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChuot : MonoBehaviour
{
    private int newOrderInLayer = 2;
    private int newOrderInLayer1 = 4;
    private bool isTouching;
    public GameObject Chuot;
    public AnimBua animBua;
    public Animchuot animchuot;
    public Sprite normalChuot;
    public Sprite stunChuot;
    private TickCompleteLevel tickCompleteLevel;
    private LevelManager levelManager;
    bool isClick = false;
    private bool hasCoroutineStarted = false;
    private SpriteRenderer spriteRenderer;  
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isTouching = false;
    }

    private void Update()
    {
        if (isClick)
        {
            BoxCollider2D chuot = Chuot.GetComponent<BoxCollider2D>();

            Vector2 topLeft = new Vector2(chuot.bounds.min.x, chuot.bounds.max.y);
            Vector2 bottomRight = new Vector2(chuot.bounds.max.x, chuot.bounds.min.y);

            Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));
            if (!isTouching && overlapResult != null)

            {

                isTouching = true;

                animBua.Toggle();                 
            }
        }
        if (isTouching && !isClick && !hasCoroutineStarted)
        {
            hasCoroutineStarted = true;
            StartCoroutine(PerformActionAfterOneSecond());
        }
    }
   
    private void OnMouseDrag()
    {
        isClick = true;
        var pos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        pos.z = transform.position.z;
        transform.position = pos;
        SetOrderInLayer();
    }

    private void SetOrderInLayer()
    {
        spriteRenderer.sortingOrder = newOrderInLayer;
    }

    private void SetOrderInLayer1()
    {
        spriteRenderer.sortingOrder = newOrderInLayer1;
    }

    private void OnMouseUp()
    {
        Debug.Log("anc");
        isClick = false;
    }

    private IEnumerator PerformActionAfterOneSecond()
    {
        yield return new WaitForSeconds(1.15f); // Chờ 1 giây
        // Thực hiện hành động của bạn tại đây
        // Cập nhật vị trí của tickCompleteLevel theo vị trí của Chuot
        tickCompleteLevel.transform.position = Chuot.transform.position;
        SetOrderInLayer1();
        animBua.ToggleOff();
        ToggleEyes();
        levelManager.CompleteLevel();
        tickCompleteLevel.Tick();
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
