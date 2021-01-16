using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        bool fire = Input.GetMouseButtonDown(0);
        if (fire == true)
        {
            Vector3 placePos = this.transform.position;

            Vector3 angle = transform.eulerAngles;
            angle.x -= 90.0f;
            Quaternion q1 = Quaternion.Euler(angle);
            Instantiate(bullet, placePos, q1);
        }
    }
}
