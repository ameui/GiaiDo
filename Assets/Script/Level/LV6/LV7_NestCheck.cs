using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR;

public class LV7_NestCheck : MonoBehaviour
{


    public LV7HenMove henMove;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public float delayTime = 0.5f;
    private BoxCollider2D nest;
    public EffEndLevel effEndLevel;

    private void Awake()
    {
        nest = GetComponent<BoxCollider2D>();
        nest.enabled = false;
    }
    void Start()
    {
 
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        henMove = GameObject.FindObjectOfType<LV7HenMove>();  
    }

    // Hàm gọi khi nhấp chuột vào đối tượng này
    public void OnMouseDown()
    {
        if (henMove.isTouching == false)
        {
            effEndLevel.Show();
            tickCompleteLevel.Tick();
            Invoke("FunctionToCall", delayTime);
        }
       

    }

    private void FunctionToCall()
    {
        levelManager.CompleteLevel();
    }

    public void nestEnable()
    {
        nest.enabled = true;
    }

    public void nestDisable()
    {
          nest.enabled = false;
    }
}
