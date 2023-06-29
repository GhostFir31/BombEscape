using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Velocidad de la bala
    
    
    public float damage;
    private Vector3 currentPos;
    private Vector3 initialPos;
    private float aux;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       aux += Time.deltaTime;

        //Conocer la posicion actual
        if(aux >= 3f){
        Destroy(gameObject);
       aux = 0f;
       }
            

        
    }
}