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
        //�θ��� ��ŸƮ�� �ؾ��Ѵ� ������� �Ф�
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
            // Ű�Է��� �������� �ȿ����̰� .. �̷��� �˹� �����Ѱ� ?
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            moveDir = new Vector2(horizontal, 0).normalized * 0.01f;
            moveDir = Vector2.zero;
        }    
        else
        {   // Ű �Է��� �������� �ٽ� ȸ���� �����ְ� , ���⺤�� �븻���� moveDir�� ������ش�
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            moveDir = new Vector2(horizontal, 0).normalized;
            //�̶� y���� �ʿ��� �ϴ� ����
        }
    }

    protected override void HandleAction()
    {

        //���� ���콺�� ��ġ
        Vector2 mousePos = Input.mousePosition;

        //��ũ����ǥ�迡�� ���� ��ǥ��� �ٲ� ī�޶��� ������ǥ �������Լ� ( �� �� ��� �ΰ� ?? TIL ����)
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);

        lookDir = (worldPos - (Vector2)transform.position);

        // ����ó��
        // 0.9���� ���� ������ ��� ??
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
            Debug.Log("���� ���� !");
        }
    }
}
