using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 playerpos;

    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float jumpPow;
    [SerializeField]
    public float rotateSpeed;

    private float x;
    private float z;


    [SerializeField]
    private Rigidbody rb1;


    // Start is called before the first frame update
    void Start()
    {
        playerpos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //rb1.velocity = new Vector3(x * moveSpeed, 0, z * moveSpeed);

        //Vector3 diff = transform.position - playerpos;

        //if (diff.magnitude > 1.0f)
        //{
        //    transform.rotation = Quaternion.LookRotation(diff);
        //}

        //playerpos = transform.position;

    }

    private void FixedUpdate()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveForward = cameraForward * z + Camera.main.transform.right * x;

        rb1.velocity = moveForward * moveSpeed + new Vector3(0, rb1.velocity.y, 0);

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}
