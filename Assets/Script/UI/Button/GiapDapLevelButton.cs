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
        button.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        Debug.Log("abc");
        levelManager.OpenGiapDapPanel();
        gameObject.SetActive(false);
    }
    public void ShowButton()
    {
        gameObject.SetActive(true);
        /*button.enabled = true;*/
    }

}
