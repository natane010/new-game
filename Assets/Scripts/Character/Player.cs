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

    private float gravityAcceleration;

    private float gravity;

    private bool isGround;

    [SerializeField]
    private Rigidbody rb1;


    // Start is called before the first frame update
    void Start()
    {
        playerpos = GetComponent<Transform>().position;
        gravity = 0;
        gravityAcceleration = 0.98f;
        isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (!isGround)
        {
            //gravity -= gravityAcceleration;
            //rb1.velocity = new Vector3(0, gravity, 0);
        }
        else if (isGround)
        {
            gravity = 0;
        }


    }

    private void FixedUpdate()
    {
        if (isGround)
        {
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            Vector3 moveForward = cameraForward * z + Camera.main.transform.right * x;

            Debug.Log(rb1.velocity);
            Vector3 nextPos = rb1.position + moveForward * moveSpeed;


            //瞬間移動するから対策

            RaycastHit hit;
            Ray ray = new Ray(nextPos, Vector3.down);
            if(Physics.Raycast(ray, out hit, 1.0f, LayerMask.GetMask("Field")))
            {
                nextPos = hit.point;
            }

            rb1.position = nextPos;

            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }
        }
        Debug.Log(isGround);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            //rb1.velocity = Vector3.zero;
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            isGround = false;
        }
    }
}
