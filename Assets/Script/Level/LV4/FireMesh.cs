using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMesh : MonoBehaviour
{
    [SerializeField]
    private bool isMerged = false;
    private int mergeCount = 0;
    private LevelManager levelManager;

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log("OnCollisionEnter2D called");
    //    if (other.gameObject.CompareTag("Fire"))
    //    {
    //        float newSize = transform.localScale.x + other.transform.localScale.x;
    //        Debug.Log("newSize" + newSize);
    //        transform.localScale = new Vector3(newSize, newSize, newSize);
    //        Debug.Log("abc" + transform.localScale);
    //        // Tiêu hủy đối tượng lửa khác sau khi hợp nhất
    //        Destroy(other.gameObject);
    //    }
    //}

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

 
    // Start is called before the first frame update
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        if (isMerged)
        {
            Destroy(gameObject);
        }
        if (mergeCount >= 3)
        {
            levelManager.CompleteLevel();
        }
    }
}
