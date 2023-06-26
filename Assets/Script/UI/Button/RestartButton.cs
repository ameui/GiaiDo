using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button button;
    public AudioClip clickButton;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnRestartLevelButtonClick);
    }
    public void OnRestartLevelButtonClick()
    {
        AudioManager.Instance.PlaySFX(clickButton);
        LevelManager.Instance.UpdateLevels();
        GameManager.Instance.gameState = GameManager.GameState.Playing;
    }
}
