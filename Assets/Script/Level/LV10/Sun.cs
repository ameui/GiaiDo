using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private BoxCollider2D sun;
    void Start()
    {
        sun = GetComponent<BoxCollider2D>();
        sun.enabled = false;
    }

    public void OnBoxSun()
    {
        sun.enabled = true;
    }
}
