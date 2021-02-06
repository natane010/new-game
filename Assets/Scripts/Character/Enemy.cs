using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    public float enemyHP;
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
    private Vector3 forward;
    private Quaternion rotation;

    private float x;
    private float y;
    private float z;

    bool fire;
    float count = 0;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject gun;
    [SerializeField]
    AudioClip canon;
    AudioSource audioSource2;
    [SerializeField]
    private GameObject elect;
    [SerializeField]
    private GameObject explosion;

    cheakTarget cheakTarget = new cheakTarget();
    Move move = new Move();

    // Start is called before the first frame update
    void Start()
    {
        enemyPos = GetComponent<Rigidbody>().position;
        audioSource2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
        cheakPlayer();
        //cheakBullet();
        Rotation();
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
        float distance = Mathf.Sqrt(DisX + DisY + DisZ);
        //距離によって移動・攻撃切り替える。
        if (distance > 100)//遠い
        {
            this.transform.position += (targetpos.transform.position - transform.position) * Time.deltaTime;
        }
        else if (distance < 1000)//近い
        {
            if (player)
            {
                fire = true;
            }
            else
            {
                fire = false;
            }
        }
        else
        {
            if (player)
            {
                fire = true;
            }
            else
            {
                fire = false;
            }
        }
    }

    private void FixedUpdate()
    {
        count++;
        move.MoveRb(enemyRbMain, enemyRbBackpack, velocity, isGround);
        Attack();
    }
    void Attack()
    {
        if (fire == true && count >= 60)
        {
            Vector3 placePos = gun.transform.position;

            Vector3 angle = transform.eulerAngles;
            angle.x -= 90.0f;
            Quaternion q1 = transform.rotation * Quaternion.Euler(0, 0, 0);
            Instantiate(bullet, placePos, q1);
            audioSource2.PlayOneShot(canon);
            count = 0;
        }
    }
    void Rotation()
    {
        //a.y = this.transform.position.y;
        Vector3 a = targetpos.transform.position;
        transform.LookAt(a);
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
       
        enemyHP -= 3000;
        if (enemyHP <= 5000)
        {
            
            Instantiate(elect, this.transform.position, Quaternion.identity);
        }
        else if (enemyHP <= 0)
        {
            
            Destroy(elect);
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
