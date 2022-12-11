using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandColor : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private SpriteRenderer SpriteRend;

    [Header("Debug Tool")]
    [SerializeField] private float r = 1;
    [SerializeField] private float g = 1;
    [SerializeField] private float b = 1;
    [SerializeField] private float a = 1;

    void Start()
    {
        // Note: Min Inclusive, Max Exclusive

        // Random
        r = Mathf.Clamp01(Random.Range(0.0f, 1.0f));
        g = Mathf.Clamp01(Random.Range(0.0f, 1.0f));
        b = Mathf.Clamp01(Random.Range(0.0f, 1.0f));
        a = Mathf.Clamp01(Random.Range(0.85f, 1f));

        // Application
        Color newColor = new Color(r, g, b, a);
        SpriteRend.color = newColor;
    }
}