using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV3_MelonBite : MonoBehaviour
{
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    // Start is called before the first frame update
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();   
    }

    private void OnMouseDown()
    {
        // Kiểm tra xem chuột có chạm vào đối tượng không
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            // Chuột chạm vào đối tượng này
            Debug.Log("Chuột chạm vào đối tượng: " + gameObject.name);

            // Thực hiện hành động khi chạm vào đối tượng
            if (transform.position.x == -1.438f && transform.position.y == 0.028f)
            {
                levelManager.CompleteLevel();
                tickCompleteLevel.Tick();   
            }
        }
        else
        {
            // Chuột không chạm vào đối tượng này
            Debug.Log("Không chạm vào đối tượng: " + gameObject.name);
        }
    }
}
