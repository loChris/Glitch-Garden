using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defender;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnDefender(GetSquareClicked());
        }    
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(
            Input.mousePosition.x,
            Input.mousePosition.y
            );

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPosition = SnapToGridPosition(worldPosition);

        return gridPosition;
    }

    private Vector2 SnapToGridPosition(Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);
        
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedGridPosition)
    {
        GameObject newDefender = Instantiate(
            defender,
            roundedGridPosition,
            quaternion.identity
        ) as GameObject;
    }
}
