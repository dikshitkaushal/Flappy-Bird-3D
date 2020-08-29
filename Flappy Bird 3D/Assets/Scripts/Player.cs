using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float forwardforce = 5.0f;
    [SerializeField] float upwardforce = 100.0f;
    Rigidbody m_rb;
    public bool dead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * forwardforce);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_rb.AddForce(Vector3.up * upwardforce);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "dead")
        {
            dead = true;
            forwardforce = 0;
            upwardforce = 0;
        }
    }
}
