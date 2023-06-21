using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffEndLevel : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }   
    public void Show()
    {
        gameObject.SetActive(true);
    }
}
