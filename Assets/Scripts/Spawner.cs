using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// FOR ENEMY

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _slimeEnemy;

    [Header("Spawn Setting")]
    [SerializeField] private float _initialSpawnInterval;
    [SerializeField] private float _minSpawnInterval;
    [SerializeField] private float _maxSpawnInterval;
    [SerializeField] private float _curSpawnInterval;

    private void Start()
    {
        // INITIAL COROUTINE START
        StartCoroutine(SpawnEnemy(_initialSpawnInterval, _slimeEnemy));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);

        // START NEXT COROUTINE
        _curSpawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
        interval = _curSpawnInterval;
        StartCoroutine(SpawnEnemy(interval, enemy));
    }
}
