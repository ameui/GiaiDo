using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoverManager : MonoBehaviour
{
    public List<GameObject> moveableObjects;
    private int currentObjectIndex = 0;

    public delegate void OnActiveObjectChanged(GameObject activeObject);
    public event OnActiveObjectChanged onActiveObjectChanged;

    private void Awake()
    {
        if (moveableObjects.Count > 0)
        {
            SetActiveObject(moveableObjects[currentObjectIndex]);
        }
    }

    public void MoveNextObject()
    {
        if (currentObjectIndex < moveableObjects.Count - 1)
        {
            currentObjectIndex++;
            SetActiveObject(moveableObjects[currentObjectIndex]);
        }
    }

    private void SetActiveObject(GameObject obj)
    {
        foreach (GameObject moveableObject in moveableObjects)
        {
            if (moveableObject != null)
            {
                MoveDuoiGa moveDuoiGa = moveableObject.GetComponent<MoveDuoiGa>();
                MoveMao moveMao = moveableObject.GetComponent<MoveMao>();

                if (moveDuoiGa != null)
                {
                    moveDuoiGa.enabled = false;
                }

                if (moveMao != null)
                {
                    moveMao.enabled = false;
                }
            }
        }

        if (obj != null)
        {
            MoveDuoiGa objMoveDuoiGa = obj.GetComponent<MoveDuoiGa>();
            MoveMao objMoveMao = obj.GetComponent<MoveMao>();

            if (objMoveDuoiGa != null)
            {
                objMoveDuoiGa.enabled = true;
            }

            if (objMoveMao != null)
            {
                objMoveMao.enabled = true;
            }
        }

        onActiveObjectChanged?.Invoke(obj);
    }
}
