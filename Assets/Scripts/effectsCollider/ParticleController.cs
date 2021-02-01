using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    ParticleCollisionNotify[] particleCollisionNotifys = null;

    public AudioClip explosion1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        particleCollisionNotifys = GetComponentsInChildren<ParticleCollisionNotify>();
        for(int i = 0;i< particleCollisionNotifys.Length;i++)
        {
            //particleCollisionNotifys[i].Setup(OnParticleCollisionNotify);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 150 * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != this.gameObject.tag)
        {
            audioSource.PlayOneShot(explosion1);
            Destroy(this.gameObject);
            Instantiate(explosion, this.transform.position, Quaternion.identity);

            var player = other.GetComponent<newPlayer>();
            var enemy = other.GetComponent<Enemy>();
            if (player != null)
            {
                player.Damege();
            }
            else if (enemy != null)
            {
                enemy.Damage();
            }
        }
    }
}
