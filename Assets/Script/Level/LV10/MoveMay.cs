﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMay : ObjectMoverManager
{
    private LevelManager levelManager;
    private TickCompleteLevel tickCompleteLevel;
    private Ice ice;
    private Sun sun;
    public GameObject targetObject; // Đối tượng mà bạn muốn kiểm tra xem BoxCollider của pos có nằm hoàn toàn bên trong hay không

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        tickCompleteLevel = GameObject.FindObjectOfType<TickCompleteLevel>();
        ice = GameObject.FindObjectOfType<Ice>();
        sun = GameObject.FindObjectOfType<Sun>();
    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        sun.OnBoxSun();

        // Kiểm tra xem BoxCollider của pos có nằm hoàn toàn trong BoxCollider của targetObject hay không
        BoxCollider2D posCollider = GetComponent<BoxCollider2D>();
        BoxCollider2D targetCollider = targetObject.GetComponent<BoxCollider2D>();

        // Kiểm tra xem các hộp có giao nhau hay không
        bool areCollidersIntersecting = posCollider.bounds.Intersects(targetCollider.bounds);

        // Nếu các hộp không giao nhau
        if (!areCollidersIntersecting)
        {
            ice.DaTan();
            tickCompleteLevel.Tick();
            levelManager.CompleteLevel();
        }

    }
}
