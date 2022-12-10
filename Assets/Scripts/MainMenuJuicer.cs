using TMPro;
using UnityEngine;

public class MainMenuJuicer : MonoBehaviour
{
    [Header("Player in Main Menu")]
    public Transform Player;
    public Transform TeleportTarget;

    [Header("Highscore Display")]
    public TextMeshProUGUI Score_Best_Display;
    public int Score_Best;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Player.position = TeleportTarget.position;
        }
    }

    private void Update()
    {
        Score_Best = PlayerPrefs.GetInt("BestScore");
        Score_Best_Display.text = Score_Best.ToString();
    }
}
