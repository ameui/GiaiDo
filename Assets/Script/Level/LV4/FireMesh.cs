using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMesh : MonoBehaviour
{
    [SerializeField]
    private bool isMerged = false;
    public bool EndLevel = false;
    private LevelManager levelManager;
    private bool isComplete = false;
    private int mergeCount = 0;
    private TickCompleteLevel tickCompleteLevel;
    private Transform tickTransform; // Thêm biến tickTransform để lưu trữ vị trí của đối tượng TickCompleteLevel
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        StartCoroutine(CheckEndLevel()); // Bắt đầu Coroutine CheckEndLevel
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        if (tickCompleteLevel != null)
        {
            tickTransform = tickCompleteLevel.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isMerged) return; // Nếu đối tượng này đã bị hợp nhất, không xử lý va chạm nữa

        if (other.gameObject.CompareTag("Fire"))
        {
            FireMesh otherFireController = other.GetComponent<FireMesh>();

            // Chỉ hợp nhất đối tượng lửa nếu nó chưa bị hợp nhất và nhỏ hơn đối tượng hiện tại
            if (!otherFireController.isMerged && other.transform.localScale.x < transform.localScale.x)
            {
                float newSize = transform.localScale.x + other.transform.localScale.x;
                transform.localScale = new Vector3(newSize, newSize, newSize);

                otherFireController.isMerged = true; // Đánh dấu đối tượng lửa khác đã bị hợp nhất
                mergeCount++; // Tăng số lần hợp nhất
            }
        }
    }

    private void Update()
    {
        if (isMerged)
        {
            Destroy(gameObject);
        }
        // Đếm số lượng đống lửa còn lại trong cảnh
        int fireCount = GameObject.FindGameObjectsWithTag("Fire").Length;

        if (fireCount == 1) // Nếu chỉ còn một đống lửa duy nhất
        {
            isComplete = true;
        }
        if (isComplete && !isMerged)
        {
            EndLevel = true;
            
            
        }
    }
    private IEnumerator CheckEndLevel()
    {
        while (!EndLevel)
        {
            yield return null; // Chờ đợi cho đến khi khung hình tiếp theo
        }
        if (tickTransform != null)
        {
            tickTransform.position = transform.position; // Di chuyển đối tượng TickCompleteLevel đến vị trí của đống lửa cuối cùng
        }
        if (tickCompleteLevel != null)
        {
            tickCompleteLevel.Tick();
        }
        // Khi EndLevel trở thành true, gọi hàm CompleteLevel
        levelManager.CompleteLevel();
    }
}

