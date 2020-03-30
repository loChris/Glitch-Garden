using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private bool _spawn = true;
    [SerializeField] private float _minSpawnDelay = 1f;
    [SerializeField] private float _maxSpawnDelay = 5f;
    [SerializeField] private Attacker _lizardManPrefab;
    
    void Start()
    {
        StartCoroutine(EnemySpawnerRoutine());
    }

    IEnumerator EnemySpawnerRoutine()
    {
        while (_spawn)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Instantiate(_lizardManPrefab, transform.position, transform.rotation);
    }
}
