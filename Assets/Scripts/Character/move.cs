using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void MoveRb(Rigidbody rbMain, Rigidbody rbBackpack, Vector3 velocity, bool isGround, float limitSpeed)
    {
        Vector3 moveSpeed = rbMain.velocity;
        if (moveSpeed.magnitude >= limitSpeed)
        {
            rbMain.velocity -= (moveSpeed / 2) * Time.deltaTime;
            rbBackpack.velocity -= (moveSpeed / 2) * Time.deltaTime;
        }
        if (isGround)
        {
            rbMain.velocity += velocity * Time.deltaTime;
            rbBackpack.velocity += velocity * Time.deltaTime;
        }
        else
        {
            rbMain.velocity += velocity / 2 * Time.deltaTime;
            rbBackpack.velocity += velocity / 2 * Time.deltaTime;
        }

    }
    public void Jump(Rigidbody rbBackpack, Rigidbody rbLegRight, Rigidbody rbLegLeft, float jumpPow, bool isGround)
    {
        rbBackpack.velocity += Vector3.up * jumpPow * Time.deltaTime;

        if (isGround)
        {
            rbBackpack.velocity += Vector3.up * jumpPow * Time.deltaTime;
            //rbLegRight.velocity += Vector3.up * jumpPow * Time.deltaTime;
            //rbLegLeft.velocity += Vector3.up * jumpPow * Time.deltaTime;
        }
    }
}
