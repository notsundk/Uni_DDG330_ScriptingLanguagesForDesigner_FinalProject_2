using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowX : MonoBehaviour
{
    public Transform Target;

    private void Update()
    {
        transform.position = new Vector2(Target.transform.position.x, transform.position.y);
    }
}
