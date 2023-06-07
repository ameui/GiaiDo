using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    public LevelManager levelManager;
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnNextLevelButtonClick);
    }
    public void OnNextLevelButtonClick()
    {
        levelManager.NextLevel();
    }
}
