using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayer : MonoBehaviour
{
    //Vector3 playerPosition;

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
    public float boostMaxGauge;
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

    [SerializeField]
    public float searchRange;
    string searchTagName = "Enemy";
    cheakTarget cheakTarget = new cheakTarget();
    public bool isSearch;

    Move move = new Move();

    // Start is called before the first frame update
    void Start()
    {
        //playerPosition = GetComponent<Transform>().position;
        jumpCount = 0;
        leftLegCollider = leftLeg.GetComponent<IsGround>();
        rightLegCollider = rightLeg.GetComponent<IsGround>();
        playerHP = 30000;
        searchTagName = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        speed = player.velocity.magnitude;
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            velocity.z += 10.0f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocity.z *= 5;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x -= 10.0f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocity.x *= 5;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.z -= 10.0f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocity.z *= 5;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += 10.0f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocity.x *= 5;
            }
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
        if (isGround && boostGauge < boostMaxGauge)
        {
            boostGauge++;
        }
        else if (boostGauge < boostMaxGauge)
        {
            boostGauge += 0.1f;
        }
        isSearch = cheakTarget.IsSearch(this.gameObject, searchTagName, searchRange, this.gameObject);
        Debug.Log(isSearch);
    }
    private void FixedUpdate()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        moveForward = cameraForward * velocity.z + Camera.main.transform.right * velocity.x;

        velocity = moveForward * moveSpeed * Time.deltaTime;

        if (velocity.magnitude > 0 && speed <= limitSpeed)
        {
            move.MoveRb(rbMain, rbBackpack, velocity, isGround);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3 && speed <= limitSpeed)
        {
            move.Jump(rbBackpack, rbLegRight, rbLegLeft, jumpPow, isGround);
            boostGauge -= 5;
            jumpCount++;
        }

        transform.rotation = Quaternion.LookRotation(cameraForward);
    }
   public void Damege()
    {
        playerHP -= 100;
        if (playerHP <= 0)
        {
            Lose();
        }
    }
    void Lose()
    {
        Destroy(this.gameObject);
        //爆発エフェクト入れてない
    }
}
