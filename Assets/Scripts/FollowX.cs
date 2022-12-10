using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowX : MonoBehaviour
{
    [SerializeField] private GameManager _gm;
    public Transform Target;
    public Transform DeathTarget;

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Target == null)
        {
            return;
        }

        transform.position = new Vector2(Target.transform.position.x, transform.position.y);

        if (_gm.Time_Cur <= 0)
        {
            Invoke("ChangeTarget", 0.75f);
        }
    }

    private void ChangeTarget()
    {
        Target = DeathTarget;
    }
}