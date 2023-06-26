using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2_Sun : ObjectMoverManager
{
    private TickCompleteLevel tickCompleteLevel;
    // Start is called before the first frame update
    private void Start()
    {
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        if (GameManager.Instance.gameState == GameManager.GameState.Playing)
        {
            // Kiểm tra xem chuột có chạm vào đối tượng không
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                tickCompleteLevel.Tick();
                GameManager.Instance.LevelComplete();
            }
        }
            
            
    }

}

