using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private GameManager _gm;

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lava") // If Collide with Player
        {
            _gm.Time_Cur = -1f;
        }
    }
}
