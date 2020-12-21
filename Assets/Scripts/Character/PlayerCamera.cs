using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    GameObject playerObs;

    Player player = new Player();

    private Vector3 playerPos;

    float keyInputX;
    float keyInputY;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = playerObs.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position += playerObs.transform.position - playerPos;
        playerPos = playerObs.transform.position;

        

        if (Input.GetMouseButton(0))
        {
            keyInputX = Input.GetAxis("Mouse X");
            keyInputY = Input.GetAxis("Mouse Y");

            transform.RotateAround(playerPos, Vector3.up, keyInputX * Time.deltaTime * 200f);

            transform.RotateAround(playerPos, transform.right, keyInputY * Time.deltaTime * 200f);
        }

        
       
    }
}
