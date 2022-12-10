using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// FOR ENEMY

public class Spawner : MonoBehaviour
{
    [Header("Object Setting")]
    [SerializeField] private GameObject _objectToSpawn;

    [Header("Spawn Setting")]
    [SerializeField] private float _initialSpawnInterval;
    [SerializeField] private float _minSpawnInterval;
    [SerializeField] private float _maxSpawnInterval;

    [Header("Debug Tool")]
    [SerializeField] private float _curSpawnInterval;

    private void Start()
    {
        // INITIAL COROUTINE START
        StartCoroutine(SpawnEnemy(_initialSpawnInterval, _objectToSpawn));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject newObject)
    {
        // WAIT FOR INTERVAL, THEN SPAWN OBJECT
        yield return new WaitForSeconds(interval);
        Instantiate(newObject, transform.position, Quaternion.identity);

        // START NEXT COROUTINE
        _curSpawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
        interval = _curSpawnInterval;
        StartCoroutine(SpawnEnemy(interval, newObject));
    }
}
