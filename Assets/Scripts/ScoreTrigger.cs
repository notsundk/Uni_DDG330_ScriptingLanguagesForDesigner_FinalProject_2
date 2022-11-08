using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] private GameManager _gm;
    [SerializeField] private GameObject _parentGO;
    [SerializeField] private float _deathDelay;

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            StartCoroutine(DelayDeath(_deathDelay));
        }
    }

    private IEnumerator DelayDeath(float interval)
    {
        yield return new WaitForSeconds(interval);
        Destroy(_parentGO);
        _gm.IncreaseScore(1);
    }
}