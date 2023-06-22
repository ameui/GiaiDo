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
    }    
}
