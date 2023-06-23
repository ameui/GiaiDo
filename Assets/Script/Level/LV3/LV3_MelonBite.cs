using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV3_MelonBite : MonoBehaviour
{
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public float delayTime = 0.5f;
    private BoxCollider2D MelonBite;
    // Start is called before the first frame update
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        MelonBite = GetComponent<BoxCollider2D>();
        MelonBite.enabled = false;
    }

    private void OnMouseDown()
    {
        // Kiểm tra xem chuột có chạm vào đối tượng không
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {     
            // Thực hiện hành động khi chạm vào đối tượng           
            {
                tickCompleteLevel.Tick();
                Invoke("FunctionToCall", delayTime);
            }
        }
    }
    private void FunctionToCall()
    {
        
        levelManager.CompleteLevel();
    }


    public void melonbiteEnabled()
    {
        MelonBite.enabled = true;
    }
}
