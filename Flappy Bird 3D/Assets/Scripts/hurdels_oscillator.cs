using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class hurdels_oscillator : MonoBehaviour
{
    public float Speed = 2f;
    float x;
    float ypos;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        ypos = Mathf.Sin(x) * Speed * Time.deltaTime;
        transform.position += new Vector3(transform.position.x, ypos, transform.position.z);
        x += Time.deltaTime;
    }
}
