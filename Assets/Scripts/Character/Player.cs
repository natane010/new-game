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
    public float targetRotateSpeed;

    private float horizontalx;
    private float verticalz;

    private Vector3 moveForward;

    /// <summary>
    /// 接地判定
    /// </summary>
    public bool isGround;

    [SerializeField]
    private Rigidbody rb1;


    // Start is called before the first frame update
    void Start()
    {
        playerpos = GetComponent<Transform>().position;
        isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalx = Input.GetAxis("Horizontal");
        verticalz = Input.GetAxis("Vertical");

        //if (!isGround)
        //{
        //    //gravity -= gravityAcceleration;
        //    //rb1.velocity = new Vector3(0, gravity, 0);
        //}
        //else if (isGround)
        //{
        //    gravity = 0;
        //}


    }

    private void FixedUpdate()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        moveForward = cameraForward * verticalz + Camera.main.transform.right * horizontalx;

        //Debug.Log(rb1.velocity);
        ////Vector3 nextPos = rb1.position + moveForward * moveSpeed;
        //rb1.velocity = moveForward * moveSpeed + new Vector3(0, rb1.velocity.y, 0);
        ////瞬間移動するから対策 raycast で下を見る
        //RaycastHit hit;
        //Ray ray = new Ray(nextPos, Vector3.down);
        //if(Physics.Raycast(ray, out hit, 1.0f, LayerMask.GetMask("Field")))
        //{
        //    nextPos = hit.point;
        //}
        //rb1.position = nextPos;

        if (isGround)
        {
            rb1.AddForce(new Vector3(horizontalx, 0, verticalz) + moveSpeed * moveForward * 2, ForceMode.Impulse);
        }

        //if (moveForward != Vector3.zero)
        //{
        //    Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        //}
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
