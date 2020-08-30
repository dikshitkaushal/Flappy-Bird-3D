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
    float timer = 0;
    public bool dead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        deathcanvas.enabled = false;
        nextlevelcanvas.enabled = false;
        m_rb = GetComponent<Rigidbody>();
    }

    GUIStyle guiStyle = new GUIStyle();
    private void OnGUI()
    {
        guiStyle.fontSize = 25;
        guiStyle.normal.textColor = Color.white;
        GUI.BeginGroup(new Rect(10, 10, 600, 150));
        GUI.Label(new Rect(10, 25, 500, 30), "Score : " + (int)timer, guiStyle);
        GUI.EndGroup();
    }
    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * forwardforce);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_rb.AddForce(Vector3.up * upwardforce);
        }
        if(!dead)
        {
            timer += Time.deltaTime;
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
    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    void LoadNextScene()
    {
        //CANVAS
        
        Debug.Log("nextScene");
    }
    public void loadnextscene()
    {
        SceneManager.LoadScene(2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Finish")
        {
            forwardforce = 3;
            upwardforce = 0;
            Debug.Log("Congratulations");
            nextlevelcanvas.enabled = true;
            Invoke("LoadNextScene", 2.0f);
        }
    }
}
