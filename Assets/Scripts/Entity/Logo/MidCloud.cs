using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidCloud : MonoBehaviour
{
    [SerializeField]
    public float SpeedMax;

    private float YPosMax = 5.0f;
    private float XPosMax = 10.0f;
    private float speed = 1.0f;
    private float ScaleMax = 1.2f;

    void Start()
    {
        speed = Random.Range(1.0f, SpeedMax);
    }

    void Update()
    {
        //왼쪽 이동
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void SetRandomPos(Vector3 OffsetPosition)
    {
        float posX = Random.Range(-XPosMax, XPosMax);
        float posY = Random.Range(-YPosMax, YPosMax);

        Vector3 randomPos = OffsetPosition + new Vector3(posX, posY, 0.0f);
        Debug.Log("구름 생성 ! X 위치 : " + randomPos.x);

        transform.position = randomPos;

        //크기도 랜덤
        float scaleRatio = Random.Range(1, ScaleMax);
        transform.localScale = new Vector3(scaleRatio , scaleRatio , 1.0f);

    }
}
