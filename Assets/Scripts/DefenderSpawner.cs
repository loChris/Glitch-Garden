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
            SpawnDefender();
        }    
    }

    private void SpawnDefender()
    {
        GameObject newDefender = Instantiate(
            defender,
            transform.position,
            quaternion.identity
        ) as GameObject;
    }
}
