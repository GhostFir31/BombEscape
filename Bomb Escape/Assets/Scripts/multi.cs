using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multi : MonoBehaviour
{

    
    public float maxLifeAmount = 100f; 
    public float lifeAmount; 
    public int contador = 0;

    private void Start()
    {
        lifeAmount = maxLifeAmount; 
    }

    public void TakeDamage(float damageAmount)
    {
        lifeAmount -= damageAmount; 

        if (lifeAmount <= 0f)
        {
            Die(); 
        }

        
    }

    private void Die()
    {
 
        Destroy(gameObject); 
    } 
}
