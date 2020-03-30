using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] private float _speed = .5f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * (_speed * Time.deltaTime));
    }
}
