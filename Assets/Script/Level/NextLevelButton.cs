using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    public LevelManager levelManager;
    private Button button;
    public float fadeInDuration = 2.0f; // Thời gian để hoàn thành hiệu ứng fadeIn (giây)
    public float startDelay = 0.5f; // Thời gian chờ trước khi bắt đầu hiệu ứng (giây)
    private void Start()
    {
        button = GetComponent<Button>();
        StartCoroutine(StartFadeIn());
        button.onClick.AddListener(OnNextLevelButtonClick);
    }
    public void OnNextLevelButtonClick()
    {
        levelManager.NextLevel();
    }
    private IEnumerator FadeIn()
    {
        float elapsedTime = 0.0f;

        // Lấy màu sắc hiện tại của nút
        Color buttonColor = button.image.color;

        // Đặt độ trong suốt ban đầu của nút thành 0
        buttonColor.a = 0;
        button.image.color = buttonColor;

        // Thực hiện hiệu ứng fadeIn
        while (elapsedTime < fadeInDuration)
        {
            buttonColor.a = Mathf.Clamp01(elapsedTime / fadeInDuration);
            button.image.color = buttonColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Đảm bảo rằng nút có độ trong suốt là 1 khi kết thúc hiệu ứng
        buttonColor.a = 1;
        button.image.color = buttonColor;
    }
    private IEnumerator StartFadeIn()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(FadeIn());
    }
}
