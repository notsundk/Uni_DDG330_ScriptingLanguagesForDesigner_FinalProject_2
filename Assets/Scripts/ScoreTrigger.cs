using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On All Enemies

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
        if (collision.tag == "Player") // If Collide with Player
        {
            StartCoroutine(DelayDeath(_deathDelay));
            _gm.IncreaseScore(1);
        }

        if (collision.tag == "Floor") // If Collide with Floor
        {
            StartCoroutine(DelayDeath(_deathDelay));
            // No Score
        }
    }

    private IEnumerator DelayDeath(float interval)
    {
        yield return new WaitForSeconds(interval);
        Destroy(_parentGO);
    }
}