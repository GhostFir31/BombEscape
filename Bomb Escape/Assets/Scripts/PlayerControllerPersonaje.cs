using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
  


    // Start is called before the first frame update
    void Start()
    {
        
        
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetKey(KeyCode.W)) //Mover personaje si se presiona la tecla W
        transform.Translate(Vector3.forward*movementSpeed*Time.deltaTime);

        if(Input.GetKey(KeyCode.S)) //Mover personaje si se presiona la tecla A
        transform.Translate(Vector3.back*movementSpeed*Time.deltaTime);

        if(Input.GetKey(KeyCode.A)) //Mover personaje si se presiona la tecla S
        transform.Translate(Vector3.left*movementSpeed*Time.deltaTime);

        if(Input.GetKey(KeyCode.D)) //Mover personaje si se presiona la tecla D
        transform.Translate(Vector3.right*movementSpeed*Time.deltaTime);

       if(Input.GetKeyDown(KeyCode.Space)){ //GetKeyDown para que solo salga una bala al presionar el mouse
        Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
       }
        /*if(Input.GetKeyDown(KeyCode.Space)){

            if(checkInGround())
                rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
         
         
    }*/
    }

   /* void FixedUpdate() {
        //Se asocia el input vertical y/o horizontal hacia una direccion
        Vector3 direction = new Vector3(horizontal, 0f , vertical);
        //Se determina si hay movimiento
        if (direction.magnitude > 0){
            //Se calcula el angulo del movimiento para rotar la vista del jugador en funcion de la camara.
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            if(rb.velocity.magnitude <= maxSpeed)
                rb.AddForce(moveDirection * movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

    }*/

    private bool checkInGround(){
        bool isGround = false;
        RaycastHit hit;
        float rayLength = 0.2f;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, rayLength)){
            Vector3 endPoint = new Vector3(transform.position.x, hit.transform.position.y, transform.position.z);
            Debug.DrawLine(transform.position, endPoint, Color.green);
            print(hit.transform.gameObject.name);
            isGround = true;
        }
        return isGround;
    }

    /*private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Checkpoint"))
            print("Checkpoint!");
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Checkpoint"))
            print("In safe zone");
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Checkpoint"))
            print("Exit safe zone");
    }

    private void OnCollisionStay(Collision collision) {
        if(collision.gameObject.CompareTag("Decoration"))
        print("PUSH!");
    }

    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.CompareTag("Decoration"))
        print("Stop pushing!");
    }*/
}