using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _damage = 50f;
    
    private void Update()
    {
        transform.Translate(Vector2.right * (_speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();

        if (health && attacker)
        {
            health.DealDamage(_damage);
            Destroy(gameObject);
            
            FindObjectOfType<StarDisplay>().AddStars(10);
        }
    }
}
