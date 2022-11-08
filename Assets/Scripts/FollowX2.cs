using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowX2 : MonoBehaviour
{
    public Transform Target;
    public PlayerMovement PlayerMovement;
    public float OffsetX;

    private void Update()
    {
        transform.position = new Vector2(Target.transform.position.x + OffsetX * PlayerMovement.ExposeDirX(), transform.position.y);
    }
}