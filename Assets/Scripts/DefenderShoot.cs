using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DefenderShoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectileGameObject;
    [SerializeField] private GameObject _gunGameObject;
    private AttackerSpawner _myLaneSpawner;
    private Animator _animator;


    private void Start()
    {
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (AttackerInLane())
            _animator.SetBool("IsAttacking", true);
        else
            _animator.SetBool("IsAttacking", false);
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner attackerSpawner in attackerSpawners)
        {
            bool IsCloseEnough = (
                Mathf.Abs(
                    attackerSpawner.transform.position.y - transform.position.y
                    ) -.5f <= Mathf.Epsilon
                );
            
            if (IsCloseEnough)
            {
                _myLaneSpawner = attackerSpawner;
            }
        }
    }

    private bool AttackerInLane()
    {
        if (_myLaneSpawner.transform.childCount <= 0)
            return false;
        else
            return true;
    }
    
    public void Fire()
    {
        Instantiate(_projectileGameObject, _gunGameObject.transform.position, transform.rotation);
    }
}
