using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;

    //이동 방향 벡터
    protected Vector2 moveDir = Vector2.zero;
    public Vector2 MoveDir { get { return moveDir; } }

    //바라보는 방향
    protected Vector2 lookDir = Vector2.zero;
    public Vector2 Vector2 { get { return lookDir; } }

    //넉백의 방향
    private Vector2 knockback = Vector2.zero;
    //넉백의 크기
    private float knockbackDuration = 0.0f;

    //애니메이션
    protected AnimationHandler animationHandler;
    //능력치
    protected StatHandler statHandler;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
    }


    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDir);
    }

    protected virtual void FixedUpdate()
    {
        Movement(MoveDir);

        if (knockbackDuration > 0.0f)
        {
            // 시간에 따른 넉백량 감소
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    private void Movement(Vector2 dir)
    {
        dir = dir * statHandler.Speed;

        //넉백 적용
        if(knockbackDuration > 0.0f)
        { 
            // 방향 줄여주고 , 넉백만큼 이동
            dir *= 0.2f;
            dir += knockback;
        }

        _rigidbody.AddForce(dir, ForceMode2D.Impulse);

        if (_rigidbody.velocity.x > statHandler.Speed)
            _rigidbody.velocity = new Vector2(statHandler.Speed, _rigidbody.velocity.y);
        else if(_rigidbody.velocity.x < -statHandler.Speed)
            _rigidbody.velocity = new Vector2(-statHandler.Speed, _rigidbody.velocity.y);

        animationHandler.Move(dir);
    }

    private void Rotate(Vector2 dir)
    {
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // 직각삼각형의 밑변 y 와 , x를 이용 , 각도값 구함. 이때 라디안 나오니까 디그리로 변경 ( 3.14 -> 180 으로 변경 )

        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
        //바라보는 방향을 구했으니 , 90보다 크면 , 왼쪽이라는 뜻임

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
