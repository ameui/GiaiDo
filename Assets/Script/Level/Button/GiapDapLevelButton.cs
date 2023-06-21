using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiapDapLevelButton : MonoBehaviour
{
    public LevelManager levelManager;
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnGiaiDapLevelButtonClick);
    }
    public void OnGiaiDapLevelButtonClick()
    {
        Debug.Log("abc");
        levelManager.OpenGiapDapPanel();
    }
    
}
