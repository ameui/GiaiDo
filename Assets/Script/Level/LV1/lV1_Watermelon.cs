using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class lV1_Watermelon : MonoBehaviour
{
    private LevelManager levelManager;
    public GameObject Watermelon;
    public GameObject Mandarin;

    private bool isTouching;


    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isTouching = true;
    }

    private void Update()
    {
        BoxCollider2D watermelon = Watermelon.GetComponent<BoxCollider2D>();
        BoxCollider2D mandarin = Mandarin.GetComponent<BoxCollider2D>();

        // Kiểm tra liệu hai đối tượng có chạm vào nhau hay không
        if (isTouching && !watermelon.IsTouching(mandarin))
        {         
            isTouching = false;
            levelManager.CompleteLevel();
        }
      /*  else if (!isTouching && watermelon.IsTouching(mandarin))
        {
            isTouching = true;
        }*/
    }

    private void OnMouseDrag()
    {
        
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;

    

}

 
}
