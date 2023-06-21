using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LV7HenMove : MonoBehaviour
{
    public GameObject Nest;
    public LV7_NestCheck nestCheck;
    public bool isTouching;

    private void Start()
    {
        isTouching = true;
        nestCheck = GameObject.FindObjectOfType<LV7_NestCheck>();
    }
    private void OnMouseDrag()
    {
        nestCheck.nestEnable();
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;      
    }

    private void OnMouseUp()
    {
        BoxCollider2D nest = Nest.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(nest.bounds.min.x, nest.bounds.max.y);
        Vector2 bottomRight = new Vector2(nest.bounds.max.x, nest.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));

        if (isTouching && overlapResult == null)
        {
            isTouching = false;
        }
        else if (overlapResult != null)
        {
            isTouching = true;
        }

        if (isTouching)
        {
            nestCheck.nestDisable();
        }
        else
        {
            nestCheck.nestEnable();
        }
    }
}
