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
        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(0, 1, 0)).normalized;
        moveForward = cameraForward * velocity.z + Camera.main.transform.right * velocity.x;

        Vector3 point = Camera.main.transform.position + (Camera.main.transform.forward * 30.0f);
        Vector3 forward = (point - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(forward);
        Vector3 angle = rot.eulerAngles;
        transform.eulerAngles = angle;

        angle = transform.localEulerAngles;
        angle.x += 75.0f;
        angle.y = 0.0f;
        angle.z = 0.0f;
        transform.localEulerAngles = angle;
    }
}
