using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Tilemaps;

public class GameManager : MonoBehaviour
{
    [Header("VAR")]
    public float Time_Max;
    public float Time_Cur;
    public int Score_Cur;
    public int Score_Best;

    [Header("UI ELEMENTS")]
    // Gameplay
    public TextMeshProUGUI Gameplay_ScoreUI;
    public Slider Gameplay_Time;

    // Endscreen
    public TextMeshProUGUI Endscreen_ScoreUI;
    public TextMeshProUGUI Endscreen_BestScoreUI;
    public GameObject Endscreen_NewBestScoreText;

    [Header("UI")]
    public GameObject Canvas_Gameplay;
    public GameObject Canvas_Endscreen;

    private void Start()
    {
        // CHECK SYS
        Debug.Log("Game is being played on " + SystemInfo.deviceType);

        // SET TIME
        Time_Cur = Time_Max;
        
        // SET RECORED BEST SCORE
        Score_Best = PlayerPrefs.GetInt("BestScore");
        Debug.Log("Best Score: " + Score_Best);

        // TURN OFF FAN FARE
        Endscreen_NewBestScoreText.SetActive(false);
    }

    private void Update()
    {

        // RESET BEST SCORE TO 0
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("BestScore", Score_Cur);
            Debug.Log("RESET HIGH SCORE");
        }

        // LIVE SCORE
        Gameplay_ScoreUI.text = Score_Cur.ToString();

        // TIME
        Time_Cur -= Time.deltaTime;
        Gameplay_Time.value = Time_Cur / Time_Max;

        // GAME OVER STATE
        if (Time_Cur <= 0)
        {
            // ENDSCREEN OVERLAY + PAUSE
            //Time.timeScale = 0f; // TIME SCALE BREAKS SCENE LOADING
            Canvas_Gameplay.SetActive(false);
            Canvas_Endscreen.SetActive(true);

            // CHECK FOR NEW BEST SCORE
            if (Score_Cur > Score_Best)
            {
                PlayerPrefs.SetInt("BestScore", Score_Cur);
                Score_Best = PlayerPrefs.GetInt("BestScore");
                Endscreen_NewBestScoreText.SetActive(true);
            }

            // DISPLAY CUR SCORE
            Endscreen_ScoreUI.text = Score_Cur.ToString();

            // DISPLAY BEST SCORE
            Endscreen_BestScoreUI.text = Score_Best.ToString();
        }
    }

    public void IncreaseScore(int Amount)
    {
        Score_Cur += Amount;
    }
}