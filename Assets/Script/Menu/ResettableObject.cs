using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettableObject : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private TickCompleteLevel tickCompleteLevel;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
    }

    public void ResetObject()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        tickCompleteLevel.TickHide();
    }
}
