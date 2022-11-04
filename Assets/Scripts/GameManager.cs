using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        Debug.Log("Game is being played on " + SystemInfo.deviceType);
    }
}