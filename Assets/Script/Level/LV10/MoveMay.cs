using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMay : ObjectMoverManager
{
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    public Ice ice;
    public Sun sun;
    public GameObject targetObject; // Đối tượng mà bạn muốn kiểm tra xem BoxCollider của pos có nằm hoàn toàn bên trong hay không
    private bool isTouching;
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        isTouching = true;
       /* StartCoroutine(CheckEndLevel());*/ // Bắt đầu Coroutine CheckEndLevel
    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        sun.OnBoxSun();

        // Kiểm tra xem BoxCollider của pos có nằm hoàn toàn trong BoxCollider của targetObject hay không
 
        BoxCollider2D targetCollider = targetObject.GetComponent<BoxCollider2D>();

        Vector2 topLeft = new Vector2(targetCollider.bounds.min.x, targetCollider.bounds.max.y);
        Vector2 bottomRight = new Vector2(targetCollider.bounds.max.x, targetCollider.bounds.min.y);

        Collider2D overlapResult = Physics2D.OverlapArea(topLeft, bottomRight, 1 << LayerMask.NameToLayer("Hen"));

        // Nếu các hộp không giao nhau
        if (isTouching && overlapResult == null)
        {
            isTouching = false;
           
        }
    }
    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        if (IsPlaying())
        {
            if (!isTouching)
            {
                ice.DaTan();
                tickCompleteLevel.Tick();
                GameManager.Instance.LevelComplete();
            }
        }
       
    }   
    /*private IEnumerator CheckEndLevel()
    {
        while (isTouching)
        {
            yield return null; // Chờ đợi cho đến khi khung hình tiếp theo
        }
        ice.DaTan();
        tickCompleteLevel.Tick();
        LevelManager.Instance.CompleteLevel();
    }*/
}
