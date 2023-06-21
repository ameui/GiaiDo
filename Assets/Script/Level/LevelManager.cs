using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject levelCompletePanel;

    public List<GameObject> levelPrefabs; // Danh sách các level
    public int currentLevelIndex = 0; // Chỉ số của level hiện tại
    GameObject currentLevel;
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
        if (currentLevelIndex < levelPrefabs.Count - 1)
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

    public void UpdateLevels()
    {
        /*for (int i = 0; i < levels.Count; i++)
        {
            levels[i].SetActive(i == currentLevelIndex);
        }*/
        // Xóa level hiện tại khỏi scene (nếu có)
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }

        // Nạp và kích hoạt level mới từ prefab
        if (currentLevelIndex >= 0 && currentLevelIndex < levelPrefabs.Count)
        {
            currentLevel = Instantiate(levelPrefabs[currentLevelIndex]);
        }

        levelCompletePanel.SetActive(false);
    }

 /*   private void Destroy(int currentLevel)
    {
        throw new NotImplementedException();
    }*/

    public void CompleteLevel()
    {
        levelCompletePanel.SetActive(true);
    }

    public void LoseLevel()
    {
        levelLosePanel.SetActive(true);
    }

}
