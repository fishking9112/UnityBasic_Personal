using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundObj : MonoBehaviour
{
    private Camera camera;
    [Range(1.0f, 10.0f)]
    [SerializeField]
    private float ratio = 1.0f;

    private Vector3 OriPos;

    void Start()
    {
        camera = Camera.main;
        OriPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        BGMoving();
    }

    void BGMoving()
    {
        if (camera != null)
        {
            //카메라의 이동값
            float CamMove_X = 0.0f - camera.transform.position.x;
            float CamMove_Y = 0.0f - camera.transform.position.y;

            // 비율만큼 나눠서 이동한다
            Vector3 pos = transform.position;
            // pos.x = transform.position.x + (CamMove_X / ratio);
            // pos.y = transform.position.y + (CamMove_Y / ratio);
            pos.x = OriPos.x - (CamMove_X / ratio);
            pos.y = OriPos.y - (CamMove_Y / ratio);
            pos.z = 0.0f;
            transform.position = pos;
        }
    }
}
