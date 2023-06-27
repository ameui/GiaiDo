using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1_Mandarin : MonoBehaviour
{
    private BoxCollider2D Mandarin;

    public void Start()
    {
        Mandarin = GetComponent<BoxCollider2D>();
        Mandarin.enabled = false;
    }

    public void madarinEnabled()
    {
        Mandarin.enabled = true;
    }
    public void madarinOff()
    {
        Mandarin.enabled = false;
    }
}

