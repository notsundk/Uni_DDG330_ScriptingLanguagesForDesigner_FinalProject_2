using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("VAR")]
    public float Time_Max;
    public float Time_Cur;
    public int Score_Cur;
    public int Score_Best;

    [Header("UI ELEMENTS")]
    public TextMeshProUGUI Gameplay_ScoreUI;
    public Slider Gameplay_Time;
    public TextMeshProUGUI Endscreen_ScoreUI;
    public TextMeshProUGUI Endscreen_BestScoreUI;

    [Header("UI")]
    public GameObject Canvas_Gameplay;
    public GameObject Canvas_Endscreen;

    private void Start()
    {
        Debug.Log("Game is being played on " + SystemInfo.deviceType);
        Time_Cur = Time_Max;
    }

    private void Update()
    {
        // LIVE SCORE
        Gameplay_ScoreUI.text = Score_Cur.ToString();

        // TIME
        Time_Cur -= Time.deltaTime;
        Gameplay_Time.value = Time_Cur / Time_Max;

        // GAME OVER STATE
        if (Time_Cur <= 0)
        {
            Canvas_Gameplay.SetActive(false);
            Canvas_Endscreen.SetActive(true);
        }
    }

    public void IncreaseScore(int Amount)
    {
        Score_Cur += Amount;
    }
}