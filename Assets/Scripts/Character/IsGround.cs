using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = new Player();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //private void OnCollisionEnter(Collision collision)
    //{

    //    //player.nowVelocity = Vector3.zero;
    //    player.isGround = true;

    //}

    //private void OnCollisionExit(Collision collision)
    //{

    //    player.isGround = false;

    //}
}
