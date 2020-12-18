using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private Vector3 playerPos;

    float mouseInputX;
    float mouseInputY;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += player.transform.position - playerPos;
        playerPos = player.transform.position;

        if (Input.GetMouseButton(1))
        {
            mouseInputX = Input.GetAxis("Mouse X");
            mouseInputY = Input.GetAxis("Mouse Y");

            transform.RotateAround(playerPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);

            transform.RotateAround(playerPos, transform.right, mouseInputY * Time.deltaTime * 200f);
        }
    }
}
