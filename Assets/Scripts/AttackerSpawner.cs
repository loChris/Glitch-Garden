using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private bool _spawn = true;
    [SerializeField] private GameObject _lizardMan;
    
    void Start()
    {
        StartCoroutine(EnemySpawnerRoutine());
    }

    IEnumerator EnemySpawnerRoutine()
    {
        while (_spawn)
        {
            Instantiate(_lizardMan);
            yield return new WaitForSeconds(Random.Range(1f, 5f));
        }
    }
}
