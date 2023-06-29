using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class PlayerControllerPersonaje : MonoBehaviour
{
    
    public float movementSpeed;
    public float maxSpeed = 10f;
    public GameObject bullet;
    public GameObject bulletSpawner; //punto de referencia de la bala
    //public Transform cam;
    public float jumpForce;
    private Rigidbody rb;
    private float horizontal;
    private float vertical;
    private float lastFireTime;

    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    public KeyCode keyAction;
    public int score = 0;
    private Vida vida;

   
    // Start is called before the first frame update
    void Start()
    {


        rb = gameObject.GetComponent<Rigidbody>();
        lastFireTime = -Mathf.Infinity;
     
    }

    // Update is called once per frame
    void Update()
    {



        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(keyUp)) //Mover personaje si se presiona la tecla W
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        if (Input.GetKey(keyDown)) //Mover personaje si se presiona la tecla A
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);

        if (Input.GetKey(keyLeft)) //Mover personaje si se presiona la tecla S
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

        if (Input.GetKey(keyRight)) //Mover personaje si se presiona la tecla D
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);

        if (Input.GetKeyDown(keyAction) && Time.time - lastFireTime >= 3f)
        {
            Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);

            lastFireTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        { //GetKeyDown para que solo salga una bala al presionar el mouse
            SceneManager.LoadScene("Menu");

        }

        
    }
    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Puntos agregados: " + points);
        Debug.Log("Puntuación total: " + score);

        if(score==3){

            SceneManager.LoadScene("Menu");

        }
    }
}