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
    private float limitSpeed;

    [SerializeField]
    GameObject targetpos;
    [SerializeField]
    GameObject bulletPos;

    bool player;
    bool playerBullet;
    bool isGround;
    public IsGround enemyleftLegCollider;
    public IsGround enemyrightLegCollider;
    public IsGround enemyLeftLegPegCollider;
    public IsGround enemyrightLegPegCollider;
    public GameObject enemyleftLeg;
    public GameObject enemyrightLeg;
    public GameObject enemyleftLegPeg;
    public GameObject enemyrightLegPeg;
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
    private GameObject elect1;
    [SerializeField]
    private GameObject elect2;
    [SerializeField]
    private GameObject elect3;
    [SerializeField]
    private GameObject elect4;
    [SerializeField]
    private GameObject explosion;

    Vector3 moveFoward;
    Vector3 targetVector;
    Vector3 nowVector;
    
    private bool hpCheak = false;
    public bool effectCheak = false;

    cheakTarget cheakTarget = new cheakTarget();
    Move move = new Move();

    bool isObstacle;
    [SerializeField]
    float jumpPow;

    // Start is called before the first frame update
    void Start()
    {
        enemyPos = GetComponent<Rigidbody>().position;
        audioSource2 = GetComponent<AudioSource>();
        enemyleftLegCollider = enemyleftLeg.GetComponent<IsGround>();
        enemyrightLegCollider = enemyrightLeg.GetComponent<IsGround>();
        enemyLeftLegPegCollider = enemyleftLegPeg.GetComponent<IsGround>();
        enemyrightLegCollider = enemyrightLegPeg.GetComponent<IsGround>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 front = this.gameObject.transform.forward;
        int layMask = ~(1 << 9);
        if (Physics.Raycast(this.gameObject.transform.position, front, 10.0f, layMask))
        {
            isObstacle = true;
        }
        else
        {
            isObstacle = false;
        }
        if (enemyHP <= 5000 && enemyHP > 0)
        {
            if (hpCheak == false)
            {
                var parent = this.transform;
                var electpos = enemyRbMain.transform.position;
                electpos.y -= 3; 
                Instantiate(elect, electpos, Quaternion.identity, parent);

                hpCheak = true;
            }
            if (effectCheak == false)
            {
                Instantiate(elect1, enemyleftLeg.transform.position, Quaternion.identity);
                Instantiate(elect2, enemyrightLeg.transform.position, Quaternion.identity);
                Instantiate(elect3, enemyRbBackpack.transform.position, Quaternion.identity);
                Instantiate(elect4, enemyRbMain.transform.position, Quaternion.identity);
                effectCheak = true;
            }
        }
        else if (enemyHP <= 0)
        {
            Instantiate(elect, enemyRbMain.transform.position, Quaternion.identity);
            Instantiate(explosion, enemyRbBackpack.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        cheakPlayer();
        //cheakBullet();
        Rotation();
        if (enemyleftLegCollider.collider1 || enemyrightLegCollider.collider1 ||
            enemyrightLegPegCollider.collider1 || enemyLeftLegPegCollider.collider1)
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
        targetVector = target.transform.position;
        nowVector = this.transform.position;
        if (distance > 100)//遠い
        {
            if (isGround)
            {
                //this.transform.position += (targetpos.transform.position - transform.position) * Time.deltaTime;
                moveFoward = targetVector - nowVector;
                velocity = moveFoward.normalized * moveSpeed;
            }
            else if (!isGround)
            {
                moveFoward = targetVector - nowVector;
                velocity = moveFoward.normalized * moveSpeed / 2;
            }
            if (distance < 1000 && player)
            {
                fire = true;
            }
            else
            {
                fire = false;
            }
        }
        else if (distance < 100)//近い
        {
            if (player)
            {
                fire = true;
            }
            else
            {
                fire = false;
            }
            if (isGround)
            {
                //this.transform.position += (targetpos.transform.position - transform.position) * Time.deltaTime;
                moveFoward = nowVector - targetVector;
                velocity = moveFoward.normalized * moveSpeed * 2;
            }
            else if (!isGround)
            {
                moveFoward = nowVector - targetVector;
                velocity = moveFoward.normalized * moveSpeed;
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
        if (isObstacle)
        {
            enemyRbMain.velocity += Vector3.up * jumpPow * Time.deltaTime;
            enemyRbBackpack.velocity += Vector3.up * jumpPow * Time.deltaTime;
        }
        count++;
        move.MoveRb(enemyRbMain, enemyRbBackpack, velocity, isGround, limitSpeed);
        Attack();
        
    }
    void Attack()
    {
        if (fire == true && count >= 20)
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
        player = cheakTarget.IsSearch(this.gameObject, "Player", 1000, this.gameObject);
    }
    void cheakBullet()
    {
        playerBullet = cheakTarget.IsSearch(this.gameObject, "Bullet", 1000, this.gameObject);
    }
    public void Damage()
    {    
        enemyHP -= 3000;
    }
    public void EffectEnd()
    {
        Debug.Log("kiteruaaa");
        effectCheak = false;
    }
}
