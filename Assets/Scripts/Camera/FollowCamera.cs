using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    [Range(0.0f , 10.0f)]
    [SerializeField]
    private float offsetX;
    [Range(0.0f, 10.0f)]
    [SerializeField]
    private float offsetY;

    // 카메라 속도
    private const float CameraMoveMaxSpeed = 5.0f;

    void Update()
    {
        if (target == null)
            return;

        Vector3 targetPos = target.position;
        targetPos.x = targetPos.x + offsetX;    // X Offset 값은 아직 없지만 , 미래를 위해 만들어만 둔다
        targetPos.y = targetPos.y + offsetY;
        //Z 값 맞춰주기
        targetPos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, targetPos, CameraMoveMaxSpeed * Time.deltaTime);
    }
}
