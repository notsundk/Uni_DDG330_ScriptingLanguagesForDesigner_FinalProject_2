using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _suicideLine;
    [SerializeField] private float _dirX;
    [SerializeField] private float _moveSpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _suicideLine = GameObject.Find("SuicideLine");
    }

    void Update()
    {
        if (transform.position.y <= _suicideLine.transform.position.y)
        {
            if (transform.position.x <= 0)
            {
                _dirX = -1;
                Debug.Log("Go Left");
            }

            if (transform.position.x >= 0)
            {
                _dirX = 1;
                Debug.Log("Go Right");
            }
        }
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_dirX * _moveSpeed, 0f);
    }
}
