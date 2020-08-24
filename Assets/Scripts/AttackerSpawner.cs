using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private bool _spawn = true;
    [SerializeField] private float _minSpawnDelay = 1f;
    [SerializeField] private float _maxSpawnDelay = 5f;
    [SerializeField] private Attacker[] _lizardManPrefabArray;
    
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

    private void StopSpawning()
    {
        _spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, _lizardManPrefabArray.Length);
        Spawn(_lizardManPrefabArray[attackerIndex]);
        
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(
            myAttacker, transform.position, transform.rotation
            ) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
