using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float countdownTime = 3f;
    public GameObject explosionEffect;
    public float explosionSize = 1f;
    public LayerMask explosionLayers;

    private bool hasExploded = false;

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private void Explode()
    {
        if (hasExploded)
            return;

        hasExploded = true;

        // Crea un efecto de explosión si se asigna un objeto
        if (explosionEffect != null)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // Crea explosiones en las direcciones X y Z
        CreateExplosion(Vector3.forward);
        CreateExplosion(Vector3.back);
        CreateExplosion(Vector3.right);
        CreateExplosion(Vector3.left);

        // Destruye la bomba
        Destroy(gameObject);
    }

    private void CreateExplosion(Vector3 direction)
    {
        // Lanza un rayo en la dirección especificada para detectar objetos en la trayectoria de la explosión
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, explosionSize, explosionLayers))
        {
            // Si se encuentra un objeto, se detiene la explosión en esa dirección
            explosionSize = hit.distance;
        }

        // Crea la explosión en la dirección especificada
        GameObject explosion = Instantiate(explosionEffect, transform.position + (direction * explosionSize), Quaternion.identity);
        explosion.transform.localScale = new Vector3(1f, 1f, explosionSize);
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(countdownTime);

        Explode();
    }
}
