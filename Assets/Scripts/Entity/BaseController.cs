using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;

    //�̵� ���� ����
    protected Vector2 moveDir = Vector2.zero;
    public Vector2 MoveDir { get { return moveDir; } }

    //�ٶ󺸴� ����
    protected Vector2 lookDir = Vector2.zero;
    public Vector2 Vector2 { get { return lookDir; } }

    //�˹��� ����
    private Vector2 knockback = Vector2.zero;
    //�˹��� ũ��
    private float knockbackDuration = 0.0f;

    //�ִϸ��̼�
    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }


    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDir);
    }

    protected void FixedUpdate()
    {
        Movement(MoveDir);

        if (knockbackDuration > 0.0f)
        {
            // �ð��� ���� �˹鷮 ����
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    private void Movement(Vector2 dir)
    {
        dir = dir * 5;

        //�˹� ����
        if(knockbackDuration > 0.0f)
        { 
            // ���� �ٿ��ְ� , �˹鸸ŭ �̵�
            dir *= 0.2f;
            dir += knockback;
        }

        _rigidbody.velocity = dir;
        animationHandler.Move(dir);
    }

    private void Rotate(Vector2 dir)
    {
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // �����ﰢ���� �غ� y �� , x�� �̿� , ������ ����. �̶� ���� �����ϱ� ��׸��� ���� ( 3.14 -> 180 ���� ���� )

        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
        //�ٶ󺸴� ������ �������� , 90���� ũ�� , �����̶�� ����

        if(weaponPivot != null)
        {
            weaponPivot.rotation = Quaternion.Euler(0 , 0 , rotZ);
        }
        
    }

    public void ApplyKnockback(Transform other , float power , float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized * power;
    }

    protected virtual void HandleAction()
    {

    }

}
