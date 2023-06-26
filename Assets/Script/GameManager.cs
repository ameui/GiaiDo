using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public AudioClip startClip;
    public AudioClip endClip;
    public enum GameState
    {
        Start,
        Playing,
        Paused,
        LevelComplete,
        GameOver
    }

    public GameState gameState;

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
    public void StartGame()
    {
        gameState = GameState.Playing;
        // Giảm âm lượng nhạc nền
        AudioManager.Instance.SetMusicVolume(0f);
        // Phát âm thanh click button
        AudioManager.Instance.PlaySFX(startClip);
        AudioManager.Instance.SetMusicVolume(0.5f);
        SceneManager.LoadScene("GameplayScene");
    }

    public void PauseGame()
    {
        gameState = GameState.Paused;
        // Hiển thị menu tạm dừng
    }

    public void ResumeGame()
    {
        gameState = GameState.Playing;
        // Ẩn menu tạm dừng
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        // Hiển thị menu kết thúc trò chơi
    }

    public void LevelComplete()
    {
        gameState = GameState.LevelComplete;
        EffectManager.Instance.effectEndLevelShow(); // Hiển thị hiệu ứng khi hoàn thành level
        AudioManager.Instance.SetMusicVolume(0f);
        AudioManager.Instance.PlaySFX(endClip);// âm thanh win
        AudioManager.Instance.SetMusicVolume(0.5f);
        Invoke(nameof(ActivateLevelCompletePanel), 0.5f); // Gọi hàm ActivateLevelCompletePanel sau 1 giây
 
    }
    private void ActivateLevelCompletePanel()
    {
        PanelManager.Instance.levelEndPanelShow(true);
        PanelManager.Instance.levelGiaiDapPanelShow(false);
        PanelManager.Instance.levelCompletePanelShow(true);
       /* EffectManager.Instance.effectEndLevelHide(); // Tắt hiệu ứng khi hoàn thành level*/
    }
   
}
