using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public MoveLid moveLid;
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    private void Start()
    {
        gameObject.SetActive(false);
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
    }

    private void Update()
    {
        if (moveLid.GetNap()) {
            if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
            {
                gameObject.SetActive(true);
                levelManager.CompleteLevel();
                tickCompleteLevel.Tick();
            }
            else
            {
                Debug.Log("abc");
            }
        }
    }
}
