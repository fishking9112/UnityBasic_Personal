using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;

    protected override void Start()
    {
        //�θ��� ��ŸƮ�� �ؾ��Ѵ� ������� �Ф�
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(horizontal, vertical).normalized;

        //���� ���콺�� ��ġ
        Vector2 mousePos = Input.mousePosition;

        //��ũ����ǥ�迡�� ���� ��ǥ��� �ٲ� ī�޶��� ������ǥ �������Լ� ( �� �� ��� �ΰ� ?? TIL ����)
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);

        lookDir = (worldPos - (Vector2)transform.position);

        // ����ó��
        // 0.9���� ū ������ ��� ??
        if(lookDir.magnitude < 0.9f)
        {
            lookDir = Vector2.zero;
        }
        else
        {
            lookDir = lookDir.normalized;
        }
    }
}
