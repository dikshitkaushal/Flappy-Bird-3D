using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    public Transform target;
    [SerializeField] float Lerp_Factor = 0.14f;
    Vector3 offset = new Vector3(6.900001f, 3.18f, -5.9f);
    Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        Quaternion angle = Quaternion.Euler(new Vector3(18.214f, -25.919f, 1.116f));
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        pos = target.position + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, pos, Lerp_Factor);
    }
}
