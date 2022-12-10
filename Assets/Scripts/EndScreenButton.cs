using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenButton : MonoBehaviour
{
    [Header("Home Button Stuff")]
    public Image Home_ButtonImage;
    public Sprite Home_ButtonDefault;
    public Sprite Home_ButtonPressed;

    [Header("Restart Button Stuff")]
    public Image Restart_ButtonImage;
    public Sprite Restart_ButtonDefault;
    public Sprite Restart_ButtonPressed;

    void Start()
    {
        Home_ButtonImage.sprite = Home_ButtonDefault;
        Restart_ButtonImage.sprite = Restart_ButtonDefault;
    }

    // Home Button
    public void HomeButtonPress()
    {
        Home_ButtonImage.sprite = Home_ButtonPressed;
        Invoke("HomeButtonUnPress", 0.125f);
        Invoke("LoadHomeScene", 0.35f);
    }

    private void HomeButtonUnPress()
    {
        Home_ButtonImage.sprite = Home_ButtonDefault;
    }

    private void LoadHomeScene()
    {
        Debug.Log("LOAD MAIN MENU");
        SceneManager.LoadScene("MainMenu");
    }

    // Restart Button
    public void RestartButtonPress()
    {
        Restart_ButtonImage.sprite = Restart_ButtonPressed;
        Invoke("RestartButtonUnPress", 0.125f);
        Invoke("RestartHomeScene", 0.35f);
    }

    private void RestartButtonUnPress()
    {
        Restart_ButtonImage.sprite = Restart_ButtonDefault;
    }

    private void RestartHomeScene()
    {
        Debug.Log("RESTART LEVEL");
        SceneManager.LoadScene("MainLevel");
    }
}
