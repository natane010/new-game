using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCamera : MonoBehaviour
{
    [SerializeField]
    GameObject mainCamera;
    [SerializeField]
    GameObject Player;
    public float rotateSpeed = 1.0f;
    float distance = 7.0f;
    float distanceLimit = 7.0f;

    private Vector3 lastMousePosition;
    private Vector3 newAngle = new Vector3(0, 0, 0);
    float x, y;

    // Start is called before the first frame update
    void Start()
    {
        //this.mainCamera = Camera.main.gameObject;
        //Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = (Player.transform.position - mainCamera.transform.position).magnitude;


        transform.position = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);

        x = Input.GetAxis("MouseX") * 1.0f;
        y = Input.GetAxis("MouseY") * 1.0f;

        y = Mathf.Clamp(y, -80, 70);

        transform.eulerAngles = new Vector3(y, x, 0);
    }
    private void rotateCamera()
    {
        
    }
}
