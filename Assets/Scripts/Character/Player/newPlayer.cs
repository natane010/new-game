﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayer : MonoBehaviour
{
    [SerializeField]
    GameController gameController;
    //Vector3 playerPosition;
    public float playerHP;
    [SerializeField]
    public float maxPlayerHp;
    [SerializeField]
    private Rigidbody player;
    [SerializeField]
    private float limitSpeed;
    private float speed;
    private float speedY;
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
    //cheakTarget cheakTarget = new cheakTarget();
    public bool isSearch;

    Move move = new Move();
    CameraShake shake;
    //DamageTime damageTime;
    GlitchFx glitch;
    bool hitdamage;
    [SerializeField]
    AudioClip biribiri;
    AudioSource audiobiribiri;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = maxPlayerHp * 1.0f;
        shake = Camera.main.GetComponent<CameraShake>();
        //damageTime = Camera.main.GetComponent<DamageTime>();
        glitch = Camera.main.GetComponent<GlitchFx>();
        glitch.enabled = !glitch.enabled;
        //playerPosition = GetComponent<Transform>().position;
        jumpCount = 0;
        leftLegCollider = leftLeg.GetComponent<IsGround>();
        rightLegCollider = rightLeg.GetComponent<IsGround>();
        searchTagName = "Enemy";
        hitdamage = false;
        boostGauge = boostMaxGauge;
        audiobiribiri = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rbBackpack.transform.position.y >= 600)
        {
            rbBackpack.velocity = Vector3.zero;
            rbBackpack.velocity = Vector3.down * jumpPow / 2;
            return;
        }
        speed = player.velocity.magnitude;
        speedY = player.velocity.y;
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            velocity.z += 10.0f;
            if (Input.GetKey(KeyCode.LeftShift) && boostGauge >= 0)
            {
                velocity.z *= 5;
                boostGauge -= 1;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x -= 10.0f;
            if (Input.GetKey(KeyCode.LeftShift) && boostGauge >= 0)
            {
                velocity.x *= 5;
                boostGauge -= 1;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.z -= 10.0f;
            if (Input.GetKey(KeyCode.LeftShift) && boostGauge >= 0)
            {
                velocity.z *= 5;
                boostGauge -= 1;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += 10.0f;
            if (Input.GetKey(KeyCode.LeftShift) && boostGauge >= 0)
            {
                velocity.x *= 5;
                boostGauge -= 1;
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
        //isSearch = cheakTarget.IsSearch(this.gameObject, searchTagName, searchRange, this.gameObject);
        //Debug.Log(isSearch);
        if (hitdamage)
        {
            glitch.enabled = !glitch.enabled;
        }
        else
        {
            glitch.enabled = false;
        }
    }
    private void FixedUpdate()
    {
        if (boostGauge < boostMaxGauge)
        {
            boostGauge += 5;
            print("kiteru");
        }

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        moveForward = cameraForward * velocity.z + Camera.main.transform.right * velocity.x;

        velocity = moveForward * moveSpeed * Time.deltaTime;
        Vector3 moveRbSpeed = rbMain.velocity;

        if (moveRbSpeed.magnitude > limitSpeed || speed > limitSpeed)
        {
            rbMain.velocity -= (moveRbSpeed / 2) * Time.deltaTime;
            rbBackpack.velocity -= (moveRbSpeed / 2) * Time.deltaTime;
        }
        if (velocity.magnitude > 0 && speed <= limitSpeed)
        {
            move.MoveRb(rbMain, rbBackpack, velocity, isGround, limitSpeed);
        }
        if (Input.GetKey(KeyCode.Space) && speed <= limitSpeed && boostGauge >= 0)
        {
            float magnification = 1;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                magnification *= 3;
            }
            move.Jump(rbBackpack, rbLegRight, rbLegLeft, jumpPow * magnification, isGround);
            boostGauge -= 5;
        }
        if (Input.GetKey(KeyCode.X) && speed <= limitSpeed && boostGauge >= 0)
        {
            float magnification = 1;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                magnification *= 3;
            }
            move.Down(rbBackpack, rbLegRight, rbLegLeft, jumpPow * magnification, isGround);
            boostGauge -= 5;
        }
        transform.rotation = Quaternion.LookRotation(cameraForward);
        Vector3 nowVector = player.velocity;
        if (playerHP <= maxPlayerHp / 2)
        {
            audiobiribiri.PlayOneShot(biribiri);
        }
    }
    public void Damege()
    {
        float damegetime = 0.0f;
        shake.Shake(0.1f, 0.1f);
        //damageTime.Noise(0.5f);
        while (damegetime < 0.5f)
        {
            if (!hitdamage)
            {
                //print("kiteru");
                hitdamage = true;
            }
            damegetime += Time.deltaTime;
        }
        Invoke("Regulation", 0.5f);
        playerHP -= 1000;
        if (playerHP <= 0)
        {
            gameController.Lose();
            Lose();
        }
    }
    void Lose()
    {
        this.gameObject.SetActive(false);
        //Destroy(this.gameObject);
        //爆発エフェクト入れてない
    }
    void Regulation()
    {
        hitdamage = false;
    }
}
