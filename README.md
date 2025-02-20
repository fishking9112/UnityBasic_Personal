TIL Link :: https://tricky-pansy-0ee.notion.site/2025-02-20-1a06ed9f4def80e29ed4d5bcd38bd9e4

![움짤1](https://github.com/user-attachments/assets/b5237bbb-5722-4f90-89f0-6cdf09684d85)

## 맵 타일 + 오브젝트 구성

![Image](https://github.com/user-attachments/assets/aadf92b7-0a45-4b84-9ceb-9173c69fba13)

바닥은 타일맵으로 , 그 위에 상호작용(충돌) 할 수 있는 오브젝트를 두었습니다.

## 팔로우 카메라 수정

특정 Offset을 두고 그대로 따라가는 카메라가 아니라 ,

Offset은 그대로 유지하되 , 러프하게 따라오는 카메라를 만들고 싶어서 기존 코드 수정.

```jsx
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
```

Vector3.Lerp를 사용. 멀어지면 빠르게 쫒아오고 , 가까울때는 기본속도로 따라오는 팔로우 카메라 설정

## Player 점프 관련 오류

점프시 위로 올라갈떄는 AddForce 하여 올라갔지만, 

내려올때는 바닥 충돌 검사부분에서 문제가있었다.

플레이어에서 바닥 방향으로 Ray를 쏴서 충돌검사 하며 해결 완료.

![Image](https://github.com/user-attachments/assets/d0da9688-ef40-4241-b548-a454ecdde025)

(빨간색 실선이 Ray의 길이와 방향)

플레이어의 중앙에서 아래방향으로 Ray를 쏴서 , 충돌 될 때 , 길이값을 체크해서 바닥체크한다.

## 이동 멈출때 미끄러짐 이슈

튜터님 강의코드에서는 이동값 + 넉백값 을 현재 포지션에 더해주기만 하면 이동이 끝났는데,

RigidBody에 AddForce 하는 식으로 움직여서, 이동이 끝나고도 Force가 남아있으면

플레이어가 미끄러지는 현상이 있었다.

아래 적는 오르막길과 연계되어 미끄러져 내려오는 문제가 생겼다

## 대각선 충돌 , 오르기

```jsx
    private void KeyInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0)
        {
            // 키입력이 없을때는 안움직이게 ..
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
```

KeyInput 메서드에서 , 현재 좌 , 우 키 입력이 없을 시,

RigidBody의 Constraint 값을 변경해주며 해결했다.

X축 이동 과 Z축 회전을 막아주고,

키 입력이 있을때만 X축 이동을 하게 하였다.

## 2D에서 배경 원근감

![Image](https://github.com/user-attachments/assets/21086fc3-1e5e-4516-a522-d2c8f51c4d4c)

횡스크롤 게임에는 Z축이 없어 평면적인 느낌만 있기 때문에,

원근감을 표현해보고싶어서

뒷 배경을 사용하여 원근감을 표현하였다.

뒷 배경들의 원점을 잡고 , 카메라의 이동값을 가져와서

비율대로 나눠서 더해주는 스크립트를 제작하였다.

가까이 있는 물체는 빠르게 , 멀리있는 물체는 느리게 움직이게 비율을 수정하여 만들었습니다.

## 로고 씬 추가Logo

![Image](https://github.com/user-attachments/assets/27aa2e3d-6eef-4cee-881a-136a4b324aa2)

씬에서 게임시작 버튼을 누르면 게임이 진행되도록 Scene추가,

버튼에서는 Event Trigger 컴포넌트를 이용하여 , 마우스가 올라오면 이미지가 바뀌게 작업하였습니다.

구름이 움직이는걸 표현하고싶어서 , 플러피버드에서 사용한 Looper 를 이용하여 구름이 움직이다가

Looper가 다시 원점으로 보내주는 방식으로 하였습니다.
