using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    private const string V = "Hen";
    private const string X = "A";
    public bool AladinChet;
    public bool AladinSo;
    public GameObject Aladin;
    private bool isTouching;

    private void Start()
    {
        isTouching = false;
        AladinChet = false;
        AladinSo = false;
    }
    private void Update()
    {
        BoxCollider2D aladin = Aladin.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(aladin.bounds.min.x, aladin.bounds.max.y);
        Vector2 bottomRight = new Vector2(aladin.bounds.max.x, aladin.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));
        Collider2D overlapResult1 = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("A"));

        if (overlapResult != null)
        {
            if (LayerMask.LayerToName(overlapResult.gameObject.layer) == V)
            {
                if (!isTouching )

                {
                    Debug.Log("abc");
                    isTouching = true;
                    AladinChet = true;
                }
            }
        }
        else
        {
            AladinChet = false;
        }
        if (overlapResult1 != null)
        {
            if (LayerMask.LayerToName(overlapResult1.gameObject.layer) == X)
            {
                if (!isTouching)

                {
                    AladinSo = true;
                }
            }          
        }else
        {
            AladinSo = false;
        }

    }
    private void OnMouseDrag()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;

    }
}
