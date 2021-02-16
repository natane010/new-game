using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    ParticleCollisionNotify[] particleCollisionNotifys = null;

    [SerializeField]
    public AudioClip explosion1;
    AudioSource audioSource;

    GameObject target;
    Enemy enemy;
    newPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        particleCollisionNotifys = GetComponentsInChildren<ParticleCollisionNotify>();
        for(int i = 0;i< particleCollisionNotifys.Length;i++)
        {
            //particleCollisionNotifys[i].Setup(OnParticleCollisionNotify);
        }
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 300 * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != this.gameObject.tag)
        {
            var tag = other.gameObject.tag;
            audioSource.PlayOneShot(explosion1);
            if (tag == "wall")
            {
                Destroy(this.gameObject);
                return;
            }
            if (tag == "Player")
            {
                
                player = other.gameObject.GetComponentInParent<newPlayer>();
            }
            else if (tag == "Enemy")
            {
                enemy = other.gameObject.GetComponentInParent<Enemy>();
            }
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            if (player == null && enemy == null)
            {
                Destroy(this.gameObject);
                return;
            }
            else if (player != null)
            {
                player.Damege();
            }
            else if (enemy != null)
            {
                enemy.Damage();
            }
            Destroy(this.gameObject);
        }
    }
}
