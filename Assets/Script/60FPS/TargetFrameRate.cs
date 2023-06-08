using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    private void Awake()
    {
        // Đặt tốc độ khung hình mục tiêu là 60 fps
        Application.targetFrameRate = 60;
    }
}
