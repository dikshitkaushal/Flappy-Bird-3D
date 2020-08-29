using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] Canvas deathcanvas;
    [SerializeField] Canvas nextlevelcanvas;
    [SerializeField] float forwardforce = 5.0f;
    [SerializeField] float upwardforce = 100.0f;
    Rigidbody m_rb;
    public bool dead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        deathcanvas.enabled = false;
        nextlevelcanvas.enabled = false;
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

            deathcanvas.enabled = true;
            //Invoke("LoadCurrentScene", 2.0f);
        }
    }
    void LoadCurrentScene()
    {
        //CANVAS
        Debug.Log("SameScene");
        
    }
    public void loadcurrentscene()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }
    void LoadNextScene()
    {
        //CANVAS
        
        Debug.Log("nextScene");
    }
    public void loadnextscene()
    {
        SceneManager.LoadScene(1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Finish")
        {
            forwardforce = 0;
            upwardforce = 0;
            Debug.Log("Congratulations");
            nextlevelcanvas.enabled = true;
            Invoke("LoadNextScene", 2.0f);
        }
    }
}
