﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltsound : MonoBehaviour
{
    [SerializeField]
    AudioClip bolt;
    AudioSource audioSource;
    [SerializeField]
    GameObject enemyob;
    Enemy enemy;
    private void Awake()
    {
        //enemyob = GameObject.Find("Enemy");
        //enemy = enemyob.GetComponent<Enemy>();
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = true;
        audioSource.PlayOneShot(bolt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsDestroy(float Hp)
    {
        
    }
}
