﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private Defender defender;
    
    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderPrice = defender.GetStarPrice();

        if (StarDisplay.HaveEnoughStars(defenderPrice))
        {
            SpawnDefender(gridPos);
            StarDisplay.spendStars(defenderPrice);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(
            Input.mousePosition.x,
            Input.mousePosition.y
            );

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPos = SnapToGridPosition(worldPosition);

        return gridPos;
    }

    private Vector2 SnapToGridPosition(Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);
        
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedGridPosition)
    {
        Defender newDefender = Instantiate(
            defender,
            roundedGridPosition,
            quaternion.identity
        ) as Defender;
    }
}
