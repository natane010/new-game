using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostBend : MonoBehaviour
{
    private Vector3 lastPos;
    float maxAngle = 60;
    float minAngle = -60;
    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deff = transform.position - lastPos;
        lastPos = transform.position;

        float rotateY = (transform.eulerAngles.y > 180) ? transform.eulerAngles.y - 360 : transform.eulerAngles.y;
        float rotateX = (transform.eulerAngles.x > 180) ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
        float rotateZ = (transform.eulerAngles.z > 180) ? transform.eulerAngles.z - 360 : transform.eulerAngles.z;

        float angleY = Mathf.Clamp(rotateY + deff.y * speed, minAngle, maxAngle);
        float angleX = Mathf.Clamp(rotateX + deff.x * speed, minAngle, maxAngle);
        float angleZ = Mathf.Clamp(rotateZ + deff.z * speed, minAngle, maxAngle);

        angleY = (angleY < 0) ? angleY + 360 : angleY;
        angleX = (angleX < 0) ? angleX + 360 : angleX;
        angleZ = (angleZ < 0) ? angleZ + 360 : angleZ;

        Vector3 angle = new Vector3(angleX, angleY, angleZ);

        if (deff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(angle);
        }
    }
}
