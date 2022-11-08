using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _slimeEnemy;
    [SerializeField] private float _spawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnEnemy(_spawnInterval, _slimeEnemy));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval, enemy));
    }
}
