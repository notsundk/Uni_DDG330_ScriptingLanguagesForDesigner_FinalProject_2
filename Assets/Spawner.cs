using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _slimeEnemy;
    [SerializeField] private float _spawnInterval;

    private void Start()
    {
        StartCoroutine(spawnEnemy(_spawnInterval, _slimeEnemy));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
