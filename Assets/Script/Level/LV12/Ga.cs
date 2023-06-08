using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ga : MonoBehaviour
{
    private BoxCollider2D ga;
    void Start()
    {
        ga = GetComponent<BoxCollider2D>();
        ga.enabled = false;
    }

    public void OnBoxGa()
    {
        ga.enabled = true;
    }
}
