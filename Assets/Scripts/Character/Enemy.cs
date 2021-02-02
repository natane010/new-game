using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveMode
{
    Idle = 0,
    Move = 1,
    Boost = 2
}
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float enemyHP;
    [SerializeField]
    Rigidbody target;
    [SerializeField]
    private Rigidbody enemyRbBackpack;
    [SerializeField]
    private Rigidbody enemyRbLegRight;
    [SerializeField]
    private Rigidbody enemyRbLegLeft;
    [SerializeField]
    private Rigidbody enemyRbMain;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    GameObject targetpos;
    [SerializeField]
    GameObject bulletPos;

    bool player;
    bool playerBullet;
    bool isGround;
    public IsGround enemyleftLegCollider;
    public IsGround enemyrightLegCollider;
    public GameObject enemyleftLeg;
    public GameObject enemyrightLeg;

    public bool isAttack;

    private Vector3 enemyPos;
    private Vector3 velocity;

    private float x;
    private float y;
    private float z;

    cheakTarget cheakTarget = new cheakTarget();
    Move move = new Move();

    // Start is called before the first frame update
    void Start()
    {
        enemyPos = GetComponent<Rigidbody>().position;
        //enemyleftLegCollider = enemyleftLeg.GetComponent<IsGround>();
        //enemyrightLegCollider = enemyrightLeg.GetComponent<IsGround>();
    }

    // Update is called once per frame
    void Update()
    {
        var aim = targetpos.transform.position - this.transform.position;
        var look = Quaternion.LookRotation(aim);
        this.transform.localRotation = look;
        cheakPlayer();
        cheakBullet();
        if (enemyleftLegCollider.collider1 && enemyrightLegCollider.collider1 || enemyleftLegCollider.collider1 && !enemyrightLegCollider.collider1 || !enemyleftLegCollider.collider1 && enemyrightLegCollider.collider1)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        float DisX = Mathf.Pow(this.transform.position.x - targetpos.transform.position.x, 2);
        float DisY = Mathf.Pow(this.transform.position.y - targetpos.transform.position.y, 2);
        float DisZ = Mathf.Pow(this.transform.position.z - targetpos.transform.position.z, 2);
        float nowDis = Mathf.Sqrt(DisX + DisY + DisZ);
        if (nowDis > 100)//遠い
        {

        }
        else if (nowDis < 100)//近い
        {

        }
        else
        {

        }
    }

    private void FixedUpdate()
    {
        move.MoveRb(enemyRbMain, enemyRbBackpack, velocity, isGround);
    }
    void boost()
    {

    }
    void Attack()
    {

    }
    void cheakPlayer()
    {
        player = cheakTarget.IsSearch(this.gameObject, "Player", 100, this.gameObject);
    }
    void cheakBullet()
    {
        playerBullet = cheakTarget.IsSearch(this.gameObject, "Bullet", 1000, this.gameObject);
    }
    public void Damage()
    {
        enemyHP -= 100;
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
