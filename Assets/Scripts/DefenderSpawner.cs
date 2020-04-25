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

        return worldPosition;
    }

    private void SpawnDefender(Vector2 worldPosition)
    {
        GameObject newDefender = Instantiate(
            defender,
            worldPosition,
            quaternion.identity
        ) as GameObject;
    }
}
