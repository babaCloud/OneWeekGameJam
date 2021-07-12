using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CutObjMove : MonoBehaviour
{
    public int dir;
    public float posX;

    private const float G = -9.8f;
    private Vector2 objPos;

    private float time = 0;

    private Vector3 startPos;
    
    void Start()
    {
        startPos = this.gameObject.transform.position;
        objPos = this.gameObject.transform.position;
    }

    
    void Update()
    {
        time += Time.deltaTime;

        objPos.x += posX *dir;
        objPos.y -= 0.02f;

        this.gameObject.transform.position = objPos;

        if (this.gameObject.transform.position.y < -2)
        {
            Recycle();
            this.gameObject.SetActive(false);
        }
    }

    void Recycle()
    {
        time = 0;
        objPos = startPos;
    }
}
