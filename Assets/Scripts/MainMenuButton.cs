using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [Header ("Start Button Stuff")]
    public Image StartButtonImage;
    public Sprite ButtonDefault;
    public Sprite ButtonPressed;

    void Start()
    {
        StartButtonImage.sprite = ButtonDefault;
    }

    public void ButtonPress()
    {
        StartButtonImage.sprite = ButtonPressed;
        Invoke("ButtonUnPress", 0.125f);
        Invoke("LoadScene", 0.35f);
    }

    private void ButtonUnPress()
    {
        StartButtonImage.sprite = ButtonDefault;
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("MainLevel");
    }

    ////////////////////////////////////////////////////////

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt("BestScore", 0);
    }
}
