using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _dirX;
    [SerializeField] private float _moveSpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x <= 0)
        {
            _dirX = -1;
        }

        if (transform.position.x >= 0)
        {
            _dirX = 1;
        }
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_dirX * _moveSpeed, 0f);
    }
}
