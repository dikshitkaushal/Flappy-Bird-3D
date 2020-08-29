using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class hurdels_oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movement;
    [SerializeField] float period = 2f;
    [Range(0, 1)] [SerializeField] float movementfactor;
    Vector3 startingpos;
    // Use this for initialization
    void Start()
    {
        startingpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawsinwave = Mathf.Sin(cycles * tau);
        movementfactor = rawsinwave;
        Vector3 offset = movement * movementfactor;
        transform.position = offset + startingpos;
    }
}
