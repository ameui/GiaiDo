using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LVQuest : MonoBehaviour
{
    public Text questText;

    public void SetQuest(string quest)
    {     
        questText.text = quest;
        gameObject.SetActive(true);
    }    
    public void CloseQuestPanel()
    {
 /*       ChePanel.SetActive(false);*/
        gameObject.SetActive(false);
    }

    public void OpenQuestPanel()
    {
       /* ChePanel.SetActive(true);*/
        gameObject.SetActive(true);
       
    }
}
