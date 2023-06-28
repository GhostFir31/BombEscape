using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarObjeto : MonoBehaviour
{
    private float aux;
    // Start is called before the first frame update
    void Start()
    {
        
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
