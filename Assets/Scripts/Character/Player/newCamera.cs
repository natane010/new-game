using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCamera : MonoBehaviour
{
    GameObject mainCamera;
    GameObject Player;
    public float rotateSpeed = 1.0f;

    private Vector3 lastMousePosition;
    private Vector3 newAngle = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = Camera.main.gameObject;
        this.Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            newAngle = mainCamera.transform.localEulerAngles;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            rotateCamera();
        }
    }
    private void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * this.rotateSpeed, 0, 0);
        this.mainCamera.transform.RotateAround(this.Player.transform.position, Vector3.up, angle.x);
    }
}
