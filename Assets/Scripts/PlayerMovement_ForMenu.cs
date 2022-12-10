using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_ForMenu : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _dirX;
    [SerializeField] private float _moveSpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            _dirX = Input.acceleration.x;

        if (SystemInfo.deviceType == DeviceType.Desktop)
            _dirX = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_dirX * _moveSpeed, 0f);
    }

    public float ExposeDirX()
    {
        return _dirX;
    }
}