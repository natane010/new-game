using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burstDamage : MonoBehaviour
{
    [SerializeField]
    AudioClip smallBurst;
    AudioSource audioSource;

    [SerializeField]
    GameObject obj;

    Enemy enemy;
    private void Awake()
    {
        obj = GameObject.Find("Enemy");
        audioSource = GetComponent<AudioSource>();
        enemy = obj.GetComponent<Enemy>();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(smallBurst);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleSystemStopped()
    {
        Debug.Log("kiteru");
        enemy.EffectEnd();
        Destroy(this.gameObject);
    }
}
