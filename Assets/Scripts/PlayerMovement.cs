using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _parentGO;
    [SerializeField] private GameManager _gm;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _dirX;
    [SerializeField] private float _moveSpeed;

    [Header("Settings")]
    [SerializeField] private float _delayBeforeDestroyScript;
    [SerializeField] private float _shrinkSpeed;

    [Header("Debug Tool")]
    [SerializeField] private float xCur;
    [SerializeField] private float yCur;
    [SerializeField] private float zCur;
    [SerializeField] private float xDef;
    [SerializeField] private float yDef;
    [SerializeField] private float zDef;

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody2D>();

        xCur = _parentGO.transform.localScale.x;
        yCur = _parentGO.transform.localScale.y;
        zCur = _parentGO.transform.localScale.z;
        xDef = xCur;
        yDef = yCur;
        zDef = zCur;
    }

    private void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            _dirX = Input.acceleration.x;

        if (SystemInfo.deviceType == DeviceType.Desktop)
            _dirX = Input.GetAxis("Horizontal");

        if (_gm.Time_Cur <= 0)
        {
            StartCoroutine(DestroyInstruction(0));
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_dirX * _moveSpeed, 0f);
    }

    public float ExposeDirX()
    {
        return _dirX;
    }

    private IEnumerator DestroyInstruction(float interval)
    {
        Debug.Log("Start Destroy Instruction");

        // Delay script
        yield return new WaitForSeconds(interval);

        // Run for as long as Slime is bigger than 0
        while (_parentGO.transform.localScale.x >= 0)
        {
            xCur -= _shrinkSpeed * Time.deltaTime;
            yCur -= _shrinkSpeed * Time.deltaTime;
            zCur -= _shrinkSpeed * Time.deltaTime;

            float xPer = xCur / xDef;
            float yPer = yCur / yDef;
            float zPer = zCur / zDef;

            float x = xDef;
            float y = yDef;
            float z = zDef;

            x *= xPer;
            y *= yPer;
            z *= zPer;

            _parentGO.transform.localScale = new Vector3(x, y, z);

            yield return null;
        }

        // Destroy
        Debug.Log(this.gameObject + " is Destroyed");
        Destroy(_parentGO);
    }
}