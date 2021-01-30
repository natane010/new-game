using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostBend : MonoBehaviour
{
    float rotationSpeed = 0.5f;
    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deff = transform.position - lastPos;
        lastPos = transform.position;

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 boostForward = new Vector3(deff.x, cameraForward.y, deff.z).normalized;

        //Quaternion rotation = Quaternion

        if (deff.magnitude > 0.01f)
        {
            Quaternion endRot = Quaternion.LookRotation(boostForward);
            transform.rotation = Quaternion.Lerp(transform.rotation, endRot, rotationSpeed * Time.deltaTime);
        }
    }
}
