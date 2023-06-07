using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int currentLevel = 0;
    public GameObject[] levelPrefabs; // Mảng chứa prefab của từng level
    private GameObject currentLevelInstance; // Đối tượng chứa level hiện tại
    public GameObject levelContainer;
    public string levelItemTag = "LevelItem";

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

    private void DestroyLevelItems()
    {
        GameObject[] levelItems = GameObject.FindGameObjectsWithTag(levelItemTag);
        foreach (GameObject item in levelItems)
        {
            Destroy(item);
        }
    }

    /* private void Start()
     {
         LoadNextLevel();
     }*/

    public void LoadNextLevel()
    {
        currentLevel++;

        // Xoá các item của level hiện tại
        DestroyLevelItems();

        // Tải level mới
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            /*levelManager.LoadNewLevel();*/
        }
        else
        {
            Debug.LogError("LevelManager not found");
        }
    }
    /*public void LoadNextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/

}
