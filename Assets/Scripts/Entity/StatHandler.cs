using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    //SerializeField 를 이용해 인스펙터 창에서도 조절 가능
    //Range 를 이용해 바 형태로 조절할수있다
    [Range(1.0f, 20.0f)][SerializeField] private float speed = 10.0f;

    public float Speed 
    { 
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }
}
