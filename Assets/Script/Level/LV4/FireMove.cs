using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    private void OnMouseDrag()
    {
        if(GameManager.Instance.gameState == GameManager.GameState.Playing)
        {
            var currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0;
            transform.position = currentMousePosition;
        }
       
    }
}
