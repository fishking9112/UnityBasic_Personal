using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    //SerializeField �� �̿��� �ν����� â������ ���� ����
    //Range �� �̿��� �� ���·� �����Ҽ��ִ�
    [Range(1.0f, 20.0f)][SerializeField] private float speed = 10.0f;

    public float Speed 
    { 
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }
}
