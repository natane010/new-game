using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railgun : MonoBehaviour
{
    private Vector3 moveForward;
    private Vector3 velocity;
    Vector3 cameraForward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        moveForward = cameraForward * velocity.z + Camera.main.transform.right * velocity.x;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(cameraForward);
    }
}
