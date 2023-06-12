using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject levelCompletePanel;

    
    public List<GameObject> levels; // Danh sách các level
    public int currentLevelIndex = 0; // Chỉ số của level hiện tại
    private int currentLevel;
    public string[] questList; //Danh sách câu hỏi
    public LVQuest lvQuest;
    public GameObject levelLosePanel;
    public Text levelText;

    private void Start()
    {
        lvQuest = GameObject.FindObjectOfType<LVQuest>();
        levelCompletePanel.SetActive(false);
        levelLosePanel.SetActive(false); 
        UpdateLevels();
        

        // Hiển thị quest ở lv 1
        LVQuest questPanelController = FindObjectOfType<LVQuest>();
        if (questPanelController != null && questList.Length > 0)
        {
            questPanelController.SetQuest(questList[0]);
        }
        levelText.text = "Level: 1";
    }

    public void NextLevel()
    {
        if (currentLevelIndex < levels.Count - 1)
        {
            levelCompletePanel.SetActive(false);
            currentLevelIndex++;
            UpdateLevels();
            PlayerPrefs.SetInt("CurrentLevel", currentLevelIndex);
            lvQuest.OpenQuestPanel();
           
            // Hiển thị quest ở các lv tiếp theo
            LVQuest questPanelController = FindObjectOfType<LVQuest>();
            if (questPanelController != null && questList.Length > currentLevelIndex)
            {
                questPanelController.SetQuest(questList[currentLevelIndex]);
                levelText.text = "Level:" + (currentLevelIndex + 1);
            }
        }
    }

    public void RestartLevel()
    {
        // Đóng các panel (nếu đang mở)
        levelCompletePanel.SetActive(false);
        levelLosePanel.SetActive(false);

        // Đặt lại tất cả các đối tượng có thể đặt lại
        foreach (ResettableObject resettable in FindObjectsOfType<ResettableObject>())
        {
            resettable.ResetObject();
        }

        // Hiển thị quest ở Level hiện tại
        LVQuest questPanelController = FindObjectOfType<LVQuest>();
        if (questPanelController != null && questList.Length > currentLevelIndex)
        {
            questPanelController.SetQuest(questList[currentLevelIndex]);
            levelText.text = "Level:" + (currentLevelIndex + 1);
        }

    }


    private void UpdateLevels()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].SetActive(i == currentLevelIndex);
        }
    }

    public void CompleteLevel()
    {
        levelCompletePanel.SetActive(true);
    }

    public void LoseLevel()
    {
        levelLosePanel.SetActive(true);
    }
}
