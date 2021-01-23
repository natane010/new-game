using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostBend : MonoBehaviour
{
    // X方向のベクトル
    [SerializeField, Range(-5f, 5f)]
    float vectorX = 0f;

    // Z方向のベクトル
    [SerializeField, Range(-5f, 5f)]
    float vectorZ = 0f;

    // 傾きベクトルの調整値
    [SerializeField, Range(1f, 10f)]
    float devideNum = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 向きベクトルから縦の傾きを得る
        float y = Mathf.Pow((vectorX * vectorX) + (vectorZ * vectorZ), 0.5f) / devideNum;
        Vector3 tiltVector = new Vector3(vectorX, -y, vectorZ);

        // 回転をかける
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tiltVector - transform.position), 0.1f);
    }
}
