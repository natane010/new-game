using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCamera : MonoBehaviour
{
    GameObject mainCamera;
    GameObject Player;
    public float rotateSpeed = 1.0f;
    float distance = 7.0f;
    float distanceLimit = 7.0f;

    private Vector3 lastMousePosition;
    private Vector3 newAngle = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = Camera.main.gameObject;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = (Player.transform.position - mainCamera.transform.position).magnitude;

        float x = Input.GetAxis("MouseX");
        float y = Input.GetAxis("MouseY");
    }
    private void rotateCamera()
    {
        
    }
}
