using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] private float _currentSpeed = 1f;
    private GameObject _currentTarget;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * (_currentSpeed * Time.deltaTime));
        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        if (!_currentTarget)
        {
            _animator.SetBool("IsAttacking", false);
        }
    }

    public void SetMovespeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        _animator.SetBool("IsAttacking", true);
        _currentTarget = target;
    }

    public void HitCurrentTarget(float damage)
    {
        if (!_currentTarget) return;

        Health health = _currentTarget.GetComponent<Health>();
        if (health)
            health.DealDamage(damage);
    }
}
