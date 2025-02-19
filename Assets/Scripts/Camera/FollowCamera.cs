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

    // ī�޶� �ӵ�
    private const float CameraMoveMaxSpeed = 5.0f;

    void Update()
    {
        if (target == null)
            return;

        Vector3 targetPos = target.position;
        targetPos.x = targetPos.x + offsetX;    // X Offset ���� ���� ������ , �̷��� ���� ���� �д�
        targetPos.y = targetPos.y + offsetY;
        //Z �� �����ֱ�
        targetPos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, targetPos, CameraMoveMaxSpeed * Time.deltaTime);
    }
}
