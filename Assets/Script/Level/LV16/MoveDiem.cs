using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class MoveDiem : MonoBehaviour
{
    public GameObject ViTriDung;
    private bool isTouching;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public void Start()
    {
        isTouching = false;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
    }
    public void Update()
    {
        BoxCollider2D viTriDung = ViTriDung.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(viTriDung.bounds.min.x, viTriDung.bounds.max.y);
        Vector2 bottomRight = new Vector2(viTriDung.bounds.max.x, viTriDung.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));
        if( overlapResult != null)
        {
            transform.position = viTriDung.bounds.center;
            if (!isTouching)
            {
                isTouching = true;
                levelManager.CompleteLevel();
                tickCompleteLevel.Tick();
            }
            
        }
    }
    public void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
}
