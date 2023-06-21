using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMoiThu : MonoBehaviour
{
    public GameObject Insidebox;
    private bool isTouching;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;

    private void Start()
    {
        isTouching = false;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();      
    }

    private void Update()
    {
        BoxCollider2D insidebox = Insidebox.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(insidebox.bounds.min.x, insidebox.bounds.max.y);
        Vector2 bottomRight = new Vector2(insidebox.bounds.max.x, insidebox.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));

        if (!isTouching && overlapResult != null)
        {
            isTouching = true;
            tickCompleteLevel.Tick();
            levelManager.CompleteLevel();
            
        }
    }
    private void OnMouseDrag()
    {   
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;
    }
}
