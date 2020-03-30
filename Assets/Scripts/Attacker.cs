using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] private float _currentSpeed = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * (_currentSpeed * Time.deltaTime));
    }

    public void SetMovespeed(float speed)
    {
        _currentSpeed = speed;
    }
}
