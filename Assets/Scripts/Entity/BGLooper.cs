using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    public int midCloudCount = 0;
    public Vector3 cloudLastPos = Vector3.zero;

    void Start()
    {
        // �������� �ʱ� ����
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
            //offSet ã��
            Vector3 offSet = GameObject.Find("MidClouds").transform.position;
            midCloud.SetRandomPos(offSet);
        }
    }

    void Update()
    {
        
    }
}
