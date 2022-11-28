using UnityEngine;

public class MainmenuSlimeJuice : MonoBehaviour
{
    public Transform Player;
    public Transform TeleportTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Player.position = TeleportTarget.position;
        }
    }
}
