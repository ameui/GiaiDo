using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMoverManager : MonoBehaviour
{
    private Vector3 initialScale;
    /*    private Vector3 initialMousePosition;*/
    private float yOffset = 0.3f; // Độ lệch trên theo trục Y
    private float xOffset = 0.3f; // Độ lệch trên theo trục X
    private int oldOrderInLayer;
    private int newOrderInLayer = 5;
    protected SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        oldOrderInLayer = spriteRenderer.sortingOrder;
    }
    protected virtual void OnMouseDown()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Playing)
        {
            initialScale = transform.localScale;
            /*        initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);*/
            // Thay đổi kích thước đối tượng lên 1,1 lần
            transform.localScale = initialScale * 1.3f;
            // Thêm độ lệch vào vị trí của đối tượng
            transform.position = new Vector3(
                transform.position.x - xOffset,
                transform.position.y + yOffset,
                transform.position.z
            );
        }
        
    }
    protected virtual void OnMouseDrag()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Playing)
        {
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0;
            transform.position = currentMousePosition + new Vector3(-xOffset, yOffset, 0);
            spriteRenderer.sortingOrder = newOrderInLayer;
        }
           
    }
    protected virtual void OnMouseUp()
    {
        if(GameManager.Instance.gameState == GameManager.GameState.Playing)
        {
            Debug.Log("OnMouseUp");
            transform.localScale = initialScale;
            spriteRenderer.sortingOrder = oldOrderInLayer;
        }
           
        /*      transform.position = new Vector3(
                             transform.position.x - xOffset,
                             transform.position.y - yOffset,
                             transform.position.z
                                                          );*/
    }
}
