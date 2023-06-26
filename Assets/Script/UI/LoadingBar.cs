using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider loadingBar;
    public float loadingDuration = 5f;

    private float progress = 0f;

    private void Start()
    {
        StartCoroutine(LoadMenuScene());
    }

    private IEnumerator LoadMenuScene()
    {
        while (progress < 1f)
        {
            progress += Time.deltaTime / loadingDuration;
            loadingBar.value = progress;
            yield return null;
        }

        GameManager.Instance.StartGame();
    }
}

