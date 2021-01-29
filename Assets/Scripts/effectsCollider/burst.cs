using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burst : MonoBehaviour
{
    [SerializeField]
    AudioClip smallBurst;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(smallBurst);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
