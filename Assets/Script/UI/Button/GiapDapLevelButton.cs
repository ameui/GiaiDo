using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiapDapLevelButton : MonoBehaviour
{
    public AudioClip clickButton;
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        AudioManager.Instance.PlaySFX(clickButton);
        LevelManager.Instance.OpenGiapDapPanel();
        gameObject.SetActive(false);
    }
    public void ShowButton()
    {
        gameObject.SetActive(true);
        /*button.enabled = true;*/
    }

}
