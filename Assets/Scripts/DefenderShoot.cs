using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DefenderShoot : MonoBehaviour
{

    [SerializeField] private GameObject _zucchiniGameObject;
    [SerializeField] private GameObject _gunGameObject;
    private AttackerSpawner myLaneSpawner;


    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (AttackerInLane())
        {
            Debug.Log("shoot");
            //change animation state to shooting
        }
        else
        {
            Debug.Log("idle");
            //change animation state to idle
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner attackerSpawner in attackerSpawners)
        {
            bool IsCloseEnough = (Mathf.Abs(attackerSpawner.transform.position.y - transform.position.y) - 0.5 <= Mathf.Epsilon);

            if (IsCloseEnough)
            {
                myLaneSpawner = attackerSpawner;
            }
        }
    }

    private bool AttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        return true;
    }
    
    public void Fire()
    {
        Instantiate(_zucchiniGameObject, _gunGameObject.transform.position, transform.rotation);
    }
}
