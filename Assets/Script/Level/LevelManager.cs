using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instace;
    public GiapDapLevelButton giaiDapLevelButton;
    public GiaiDapLevel giaiDapLevel;
    public string[] giaidapList; // danh sách giải đáp
    public List<GameObject> levelPrefabs; // Danh sách các level
    public int currentLevelIndex = 0; // Chỉ số của level hiện tại
    GameObject currentLevel;
    public string[] questList; //Danh sách câu hỏi
    public LVQuest lvQuest;
    public Text levelText;
    public EffEndLevel effEndLevel;


    private void Awake()
    {
        instace = this;
    }

    private void Start()
    {
        lvQuest = GameObject.FindObjectOfType<LVQuest>();
        PanelManager.Instance.levelCompletePanelHide();
        PanelManager.Instance.levelQuestPanelShow();
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
            effEndLevel.Hide();
            PanelManager.Instance.levelCompletePanelHide();
            PanelManager.Instance.levelGiaiDapPanelShow();
            currentLevelIndex++;
            UpdateLevels();
            PlayerPrefs.SetInt("CurrentLevel", currentLevelIndex);
            

            // Hiển thị quest ở các lv tiếp theo
            LVQuest questPanelController = FindObjectOfType<LVQuest>();
            if (questPanelController != null && questList.Length > currentLevelIndex)
            {
                questPanelController.SetQuest(questList[currentLevelIndex]);
                levelText.text = "Level:" + (currentLevelIndex + 1);
            }

            // Ẩn văn bản giải đáp
            if (giaiDapLevel != null)
            {
                giaiDapLevel.HideText();
            }

            // Hiển thị lại nút GiaiDap ở level mới
            if (giaiDapLevelButton != null)
            {
                giaiDapLevelButton.ShowButton();
            }

            /*// load danh sách giải đáp cho các lv tiếp theo
            GiaiDapLevel giaidapPanelController = FindObjectOfType<GiaiDapLevel>();
            if (giaidapPanelController != null && giaidapList.Length > currentLevelIndex)
            {
                giaidapPanelController.SetGiaiDap(giaidapList[currentLevelIndex]);
            }*/
        }
    }

    public void OpenGiapDapPanel()
    {
        GiaiDapLevel giaidapPanelController = FindObjectOfType<GiaiDapLevel>();
        if (giaidapPanelController != null && giaidapList.Length > 0)
        {
            giaidapPanelController.SetGiaiDap(giaidapList[currentLevelIndex]);
        }
    }

    public void UpdateLevels()
    {
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
        PanelManager.Instance.levelGiaiDapPanelShow();
        if (giaiDapLevelButton != null)
        {
            giaiDapLevelButton.ShowButton();
        }
        // Ẩn văn bản giải đáp
        if (giaiDapLevel != null)
        {
            giaiDapLevel.HideText();
        }
        PanelManager.Instance.levelCompletePanelHide();
    }

 /*   private void Destroy(int currentLevel)
    {
        throw new NotImplementedException();
    }*/

    public void CompleteLevel()
    {
        Debug.Log("abc");
        effEndLevel.Show(); // Hiển thị hiệu ứng khi hoàn thành level

        Invoke(nameof(ActivateLevelCompletePanel), 1f); // Gọi hàm ActivateLevelCompletePanel sau 1 giây
    }
    private void ActivateLevelCompletePanel()
    {
        
        PanelManager.Instance.levelGiaiDapPanelHide();
        PanelManager.Instance.levelCompletePanelShow();

    }
}
