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
    public float boostMaxPower;
    public float boostPower;
    public float boostGauge;
    private float jumpCount;
    [SerializeField]
    public float targetRotateSpeed;

    [SerializeField]
    public float searchRange;

    string searchTagName;

    private float horizontalx;
    private float verticalz;

    private Vector3 moveForward;

    /// <summary>
    /// 接地判定
    /// </summary>
    public bool isGround;

    //public Vector3 nowVelocity;

    [SerializeField]
    private Rigidbody rb1;

    [SerializeField]
    GameObject playerObj;

    public GameObject leftLeg;
    public GameObject rightLeg;

    private IsGround leftLegCollider;
    private IsGround rightLegCollider;

    //--------------------------------------------
    //cheakTarget cheakTarget = new cheakTarget();

    //public bool isSearch;
    //上手くいかない
    //--------------------------------------------


    // Start is called before the first frame update
    void Start()
    {
        leftLegCollider = leftLeg.GetComponent<IsGround>();
        rightLegCollider = rightLeg.GetComponent<IsGround>();

        playerpos = GetComponent<Transform>().position;
        isGround = false;
        boostGauge = 20;
        jumpCount = 0;
        boostPower = 1;

        searchTagName = "Enemy";
        //nowVelocity = rb1.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalx = Input.GetAxis("Horizontal");
        verticalz = Input.GetAxis("Vertical");

        //isSearch = cheakTarget.IsSearch(playerObj, searchTagName, searchRange, playerObj);
        //if (!isGround)
        //{
        //    //gravity -= gravityAcceleration;
        //    //rb1.velocity = new Vector3(0, gravity, 0);
        //}
        //else if (isGround)
        //{
        //    gravity = 0;
        //}
        //Debug.Log(isSearch);

        if (leftLegCollider.collider1 && rightLegCollider.collider1 || leftLegCollider.collider1 && !rightLegCollider.collider1 || !leftLegCollider.collider1 && rightLegCollider.collider1)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    private void FixedUpdate()
    {

        //移動ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        moveForward = cameraForward * verticalz + Camera.main.transform.right * horizontalx;

        //{Debug.Log(rb1.velocity);
        ////Vector3 nextPos = rb1.position + moveForward * moveSpeed;
        //rb1.velocity = moveForward * moveSpeed + new Vector3(0, rb1.velocity.y, 0);
        ////瞬間移動するから対策 raycast で下を見る
        //RaycastHit hit;
        //Ray ray = new Ray(nextPos, Vector3.down);
        //if (Physics.Raycast(ray, out hit, 1.0f, LayerMask.GetMask("Field")))
        //{
        //    nextPos = hit.point;
        //}
        //rb1.position = nextPos;} 保留

        if (isGround)
        {
            rb1.AddForce(new Vector3(horizontalx, 0, verticalz) + moveSpeed * moveForward * boostPower * 2, ForceMode.Impulse);
            jumpCount = 0;
            if (boostGauge < 20)
            {
                boostGauge++;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb1.AddForce(Vector3.up * jumpPow);
                boostGauge -= 1;
            }
        }
        else if (!isGround)
        {
            rb1.AddForce(new Vector3(horizontalx, 0, verticalz) + moveSpeed * moveForward * boostPower / 2, ForceMode.Impulse);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb1.AddForce(Vector3.up * jumpPow);
                boostGauge -= 1;
                jumpCount++;
            }
        }

        //if (moveForward != Vector3.zero)
        //{
        //    Quaternion targetRotation = Quaternion.LookRotation(moveForward - transform.position);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        //}　保留
        Debug.Log(isGround);
        //回避
        if (Input.GetKey(KeyCode.X))
        {
            boostPower = boostMaxPower;
            if (Input.GetKeyUp(KeyCode.X))
            {
                boostPower = 0;
            }
        }
        else
        {
            boostPower = 1;
        }
    }
    //------------------------------------------------------
    //private void OnCollisionEnter(Collision collision)
    //{

    //    //player.nowVelocity = Vector3.zero;
    //    isGround = true;

    //}
    //private void OnCollisionExit(Collision collision)
    //{

    //    isGround = false;

    //}
    //＊＊＊＊＊＊＊＊＊＊＊＊
    //---------------------------------------------------------
}
