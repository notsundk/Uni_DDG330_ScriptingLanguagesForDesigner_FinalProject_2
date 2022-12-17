using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject gameplayPauseButton;
    public GameObject pausePanel;
    public bool _isPaused = false;

    public void PauseButtonPress()
    {
        _isPaused = !_isPaused;
    }

    private void Update()
    {
        PauseFunction(_isPaused);
    }

    private void PauseFunction(bool pauseState)
    {
        gameplayPauseButton.SetActive(!pauseState);
        pausePanel.SetActive(pauseState);

        if (pauseState)
        {
            Time.timeScale = 0.0f;
        }
        // Not Pause
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
