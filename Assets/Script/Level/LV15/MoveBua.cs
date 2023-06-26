using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBua : ObjectMoverManager
{
    private bool isTouching;
    public GameObject Bua;
    public Animchuot animChuot;

    bool isClickBua = false;

    public GameObject m_MyObject, m_NewObject;
    BoxCollider2D m_Collider, m_Collider2;

    void Start()
    {
        //Check that the first GameObject exists in the Inspector and fetch the Collider
        if (m_MyObject != null)
            m_Collider = m_MyObject.GetComponent<BoxCollider2D>();

        //Check that the second GameObject exists in the Inspector and fetch the Collider
        if (m_NewObject != null)
            m_Collider2 = m_NewObject.GetComponent<BoxCollider2D>();
    }

/*    void Update()
    {
        //If the first GameObject's Bounds enters the second GameObject's Bounds, output the message
        if (m_Collider.bounds.Intersects(m_Collider2.bounds))
        {
            animChuot.ToggleChuot();
        }
        else
        {
            animChuot.ToggleChuotOff();
        }
    }*/

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        isClickBua = true;
        if (m_Collider.bounds.Intersects(m_Collider2.bounds))
        {
            Debug.Log("Bua");
            animChuot.ToggleChuot();
        }
        else
        {
            Debug.Log("Bua off");
            animChuot.ToggleChuotOff();
        }
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        isClickBua = false;
    }

}
