using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    float xAngle;
    float yAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xAngle = Input.GetAxis("Mouse X");
        yAngle = Input.GetAxis("Mouse Y");
    }
}
