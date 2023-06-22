using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance { get; private set; }
    public GameObject levelCompletePanel;
    public GameObject levelGiaiDapPanel;
    public GameObject levelQuestPanel;
   

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

    public void levelCompletePanelShow()
    {
        levelCompletePanel.SetActive(true);
    }
    public void levelCompletePanelHide()
    {
        levelCompletePanel.SetActive(false);
    }
    public void levelGiaiDapPanelShow()
    {
        levelGiaiDapPanel.SetActive(true);
    }
    public void levelGiaiDapPanelHide()
    {
        levelGiaiDapPanel.SetActive(false);
    }
    public void levelQuestPanelShow()
    {
        levelQuestPanel.SetActive(true);
    }
    public void levelQuestPanelHide()
    {
        levelQuestPanel.SetActive(false);
    }
}
