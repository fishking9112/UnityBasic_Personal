using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //¿ÞÂÊ ÀÌµ¿
        transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
    }
}
