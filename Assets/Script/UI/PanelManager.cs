using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance { get; private set; }
    public GameObject levelCompletePanel;
    public GameObject levelGiaiDapPanel;
    public GameObject levelQuestPanel;
    public GameObject levelEndPanel;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void levelCompletePanelShow(bool isActive)
    {
        levelCompletePanel.SetActive(isActive);
    }
    public void levelGiaiDapPanelShow(bool isActive)
    {
        levelGiaiDapPanel.SetActive(isActive);
    }
    public void levelQuestPanelShow(bool isActive)
    {
        levelQuestPanel.SetActive(isActive);
    }
    public void levelEndPanelShow(bool isActive)
    {
        levelQuestPanel.SetActive(isActive);
    }
}
