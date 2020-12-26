using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayer : MonoBehaviour
{
    [SerializeField]
    public float playerHP;
    [SerializeField]
    private Rigidbody player;
    [SerializeField]
    private float limitSpeed;
    private float speed;
    private Vector3 velocity;
    private Vector3 moveForward;
    [SerializeField]
    private Rigidbody rbBackpack;
    [SerializeField]
    private Rigidbody rbLegRight;
    [SerializeField]
    private Rigidbody rbLegLeft;
    [SerializeField]
    private Rigidbody rbMain;
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float jumpPow;
    [SerializeField]
    public float boostMaxPower;
    public float boostPower;
    public float boostGauge;
    private float jumpCount;
    public bool isGround;

    public GameObject leftLeg;
    public GameObject rightLeg;

    private IsGround leftLegCollider;
    private IsGround rightLegCollider;

    // Start is called before the first frame update
    void Start()
    {
        jumpCount = 0;
        leftLegCollider = leftLeg.GetComponent<IsGround>();
        rightLegCollider = rightLeg.GetComponent<IsGround>();
        playerHP = 30000;
    }

    // Update is called once per frame
    void Update()
    {
        speed = player.velocity.magnitude;
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            velocity.z += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += 1;
        }
        if (leftLegCollider.collider1 && rightLegCollider.collider1 || leftLegCollider.collider1 && !rightLegCollider.collider1 || !leftLegCollider.collider1 && rightLegCollider.collider1)
        {
            isGround = true;
            jumpCount = 0;
        }
        else
        {
            isGround = false;
        }
        if (isGround)
        {
            boostGauge += 2;
        }
        else
        {
            boostGauge++;
        }
    }
    private void FixedUpdate()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        moveForward = cameraForward * velocity.z + Camera.main.transform.right * velocity.x;

        velocity = moveForward * moveSpeed * Time.deltaTime;

        if (velocity.magnitude > 0 && speed <= limitSpeed)
        {
            if (isGround)
            {
                rbLegRight.velocity += velocity;
                rbLegLeft.velocity += velocity;
                rbMain.velocity += velocity;
                rbBackpack.velocity += velocity;
            }
            else
            {
                rbMain.velocity += velocity;
                rbBackpack.velocity += velocity;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3 && speed <= limitSpeed)
        {
            rbBackpack.velocity = Vector3.up * jumpPow;
            if (isGround)
            {
                rbLegRight.velocity += Vector3.up * jumpPow;
                rbLegLeft.velocity += Vector3.up * jumpPow;
            }
            boostGauge += 5;
            jumpCount++;
        }
        
    }
}
