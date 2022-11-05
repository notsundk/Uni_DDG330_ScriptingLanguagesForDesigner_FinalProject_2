using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreUI;
    public int Score;

    private void Start()
    {
        Debug.Log("Game is being played on " + SystemInfo.deviceType);
    }

    private void Update()
    {
        ScoreUI.text = Score.ToString();
    }

    public void IncreaseScore(int Amount)
    {
        Score += Amount;
    }
}