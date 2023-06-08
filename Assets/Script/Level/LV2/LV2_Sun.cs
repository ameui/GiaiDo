using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2_Sun : MonoBehaviour
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
        /*var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;
        if(pos.x == -1.072 && pos.y == 1.199)
        {
            levelManager.CompleteLevel();
        }*/

        // Kiểm tra xem chuột có chạm vào đối tượng không
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            // Chuột chạm vào đối tượng này
            Debug.Log("Chuột chạm vào đối tượng: " + gameObject.name);

        
                levelManager.CompleteLevel();
                tickCompleteLevel.Tick();
        }
        else
        {
            // Chuột không chạm vào đối tượng này
            Debug.Log("Không chạm vào đối tượng: " + gameObject.name);
        }
    }

}

