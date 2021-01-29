using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void MoveRb(Rigidbody rbMain, Rigidbody rbBackpack, Vector3 velocity, bool isGround)
    {
        if (isGround)
        {
            rbMain.velocity += velocity;
            rbBackpack.velocity += velocity;
        }
        else
        {
            rbMain.velocity += velocity / 2;
            rbBackpack.velocity += velocity / 2;
        }
    }
    public void Jump(Rigidbody rbBackpack, Rigidbody rbLegRight, Rigidbody rbLegLeft, float jumpPow, bool isGround)
    {
        rbBackpack.velocity = Vector3.up * jumpPow;

        if (isGround)
        {
            rbLegRight.velocity += Vector3.up * jumpPow;
            rbLegLeft.velocity += Vector3.up * jumpPow;
        }
    }
}
