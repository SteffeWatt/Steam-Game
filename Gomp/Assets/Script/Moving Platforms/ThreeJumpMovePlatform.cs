using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThreeJumpMovePlatform : MonoBehaviour
{
    public Player player;
    public Transform platform;
    public Transform startPos;
    public Transform midPos;
    public Transform endPos;
    public float speed = 3f;

    Vector2 currentMovementTarget()
    {
        Transform pos;
        pos = startPos;

        if (player.Jumps == 0) { pos = startPos; }
        if (player.Jumps == 1) { pos = midPos; }
        if (player.Jumps == 2) { pos = endPos; }
        if (player.Jumps == 3) { pos = midPos; }

        return pos.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = currentMovementTarget();
        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);
    }
}

