using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;

    protected override void Start()
    {
        //부모의 스타트도 해야한다 까먹지마 ㅠㅠ
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(horizontal, vertical).normalized;

        //현재 마우스의 위치
        Vector2 mousePos = Input.mousePosition;

        //스크린좌표계에서 월드 좌표계로 바꾼 카메라의 월드좌표 역투영함수 ( 역 뷰 행렬 인가 ?? TIL 쓰자)
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);

        lookDir = (worldPos - (Vector2)transform.position);

        // 예외처리
        // 0.9보다 큰 벡터일 경우 ??
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
