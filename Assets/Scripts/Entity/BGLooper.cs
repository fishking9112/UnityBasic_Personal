using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    public int midCloudCount = 0;
    public Vector3 cloudLastPos = Vector3.zero;

    void Start()
    {
        // 작은구름 초기 생성
        MidCloud[]    midClouds = GameObject.FindObjectsOfType<MidCloud>();
        midCloudCount = midClouds.Length; 

        for(int i = 0; i < midCloudCount; i++)
        {
            midClouds[i].SetRandomPos(Vector3.zero);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        MidCloud midCloud = collision.GetComponent<MidCloud>();

        if (midCloud != null)
        {
            //offSet 찾기
            Vector3 offSet = GameObject.Find("MidClouds").transform.position;
            midCloud.SetRandomPos(offSet);
        }
    }

    void Update()
    {
        
    }
}
