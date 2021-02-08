using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectDestroy : MonoBehaviour
{
    [SerializeField]
    AudioClip smallBurst;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
        Destroy(this.gameObject);
    }
}
