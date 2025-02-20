using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;

    [SerializeField] private float jumpPower;
    protected override void Start()
    {
        //부모의 스타트도 해야한다 까먹지마 ㅠㅠ
        base.Start();
        camera = Camera.main;
    }
    protected override void Update()
    {
        base.Update();
        KeyInput();
        Jump();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        CheckLanding();
    }
    private void KeyInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0)
        {
            // 키입력이 없을때는 안움직이게 .. 이러면 넉백 가능한가 ?
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            moveDir = new Vector2(horizontal, 0).normalized * 0.01f;
            moveDir = Vector2.zero;
        }    
        else
        {   // 키 입력이 있을때는 다시 회전만 막아주고 , 방향벡터 노말값을 moveDir에 만들어준다
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            moveDir = new Vector2(horizontal, 0).normalized;
            //이때 y값은 필요없어서 일단 제외
        }
    }

    protected override void HandleAction()
    {

        //현재 마우스의 위치
        Vector2 mousePos = Input.mousePosition;

        //스크린좌표계에서 월드 좌표계로 바꾼 카메라의 월드좌표 역투영함수 ( 역 뷰 행렬 인가 ?? TIL 쓰자)
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);

        lookDir = (worldPos - (Vector2)transform.position);

        // 예외처리
        // 0.9보다 작은 벡터일 경우 ??
        if(lookDir.magnitude < 0.9f)
        {
            lookDir = Vector2.zero;
        }
        else
        {
            lookDir = lookDir.normalized;
        }
    }
    private void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Jump");
            if(animationHandler.Anim.GetBool("IsJump") == false )
            {
                _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                animationHandler.Jump(true);
            }
        }
    }
    private void CheckLanding()
    {
        if(_rigidbody.velocity.y < 0)
        {
            Vector2 rayStartPos = new Vector2(transform.position.x , transform.position.y - 0.5f);
            Debug.DrawRay(rayStartPos, Vector3.down, new Color(1, 0, 0));
            RaycastHit2D ray = Physics2D.Raycast(rayStartPos, Vector3.down, 5.0f, LayerMask.GetMask("Ground"));

            if(ray.collider != null)
            {
                if (ray.distance < 1.0f)
                {
                    animationHandler.Jump(false);
                }    
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("DungeonEnter"))
        {
            Debug.Log("던전 입장 !");
        }
    }
}
