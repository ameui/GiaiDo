using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITarget : MonoBehaviour
{
    public GameObject[] panels; // Danh sách các panel
    private GameObject currentActivePanel; // Panel hiện tại được kích hoạt

    private void Start()
    {
        // Tìm panel đầu tiên được kích hoạt trong danh sách và gán vào biến currentActivePanel
        foreach (GameObject panel in panels)
        {
            if (panel.activeInHierarchy)
            {
                currentActivePanel = panel;
                break;
            }
        }
    }

    // Hàm này sẽ bật tắt tương tác của các panel dựa trên panel hiện tại được kích hoạt
    public void ConfigurePanelInteractions()
    {
        foreach (GameObject panel in panels)
        {
            CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();

            // Nếu panel là panel hiện tại được kích hoạt, cho phép tương tác
            if (panel == currentActivePanel)
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
            // Nếu panel không phải là panel hiện tại được kích hoạt, không cho phép tương tác
            else
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
        }
    }

    // Hàm này sẽ đặt panel mới làm panel hiện tại được kích hoạt và cập nhật tương tác của các panel
    public void SetActivePanel(GameObject newActivePanel)
    {
        currentActivePanel = newActivePanel;
        ConfigurePanelInteractions();
    }
}
