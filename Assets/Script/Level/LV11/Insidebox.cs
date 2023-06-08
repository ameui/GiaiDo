using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insidebox : MonoBehaviour
{
    private BoxCollider2D insidebox;
    void Start()
    {
        insidebox = GetComponent<BoxCollider2D>();
        insidebox.enabled = false;
    }

    public void OnBoxSun()
    {
        insidebox.enabled = true;
    }
}
