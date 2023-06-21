using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaiDapLevel : MonoBehaviour
{
    public Text giaiDapText;

    public void SetGiaiDap(string quest)
    {
        giaiDapText.text = quest;
        gameObject.SetActive(true);
    }
    public void CloseGiaiDapPanel()
    {        
        gameObject.SetActive(false);
    }

    public void OpenGiaiDapPanel()
    {       
        gameObject.SetActive(true);
    }
}
