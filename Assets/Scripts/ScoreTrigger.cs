using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On All Enemies

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] private GameManager _gm;
    [SerializeField] private GameObject _parentGO;

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

        // Extract Slime Size
        xCur = _parentGO.transform.localScale.x;
        yCur = _parentGO.transform.localScale.y;
        zCur = _parentGO.transform.localScale.z;
        xDef = xCur;
        yDef = yCur;
        zDef = zCur;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // If Collide with Player
        {
            StartCoroutine(DestroyInstruction(_delayBeforeDestroyScript));
            _gm.IncreaseScore(1);
        }

        if (collision.tag == "Floor") // If Collide with Floor
        {
            StartCoroutine(DestroyInstruction(_delayBeforeDestroyScript));
            // No Score
        }

        if (collision.tag == "Lava") // If Collide with Lava
        {
            StartCoroutine(DestroyInstruction(0));
            // No Score
        }
    }

    private IEnumerator DestroyInstruction(float interval)
    {
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