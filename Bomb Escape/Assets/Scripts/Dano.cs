using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{
    public float damageAmount;
    public float raycastDistance;
    public LayerMask targetLayer;
    public LayerMask obstacleLayer;

    private void Start()
    {
        StartCoroutine(ExplodeAfterDelay());
    }

    private void Explode()
    {
        RaycastHit[] hits = new RaycastHit[10];
        int numHits = Physics.RaycastNonAlloc(transform.position, transform.forward, hits, raycastDistance, targetLayer);

        for (int i = 0; i < numHits; i++)
        {
            RaycastHit hit = hits[i];

            // Comprobar si hay un objeto de bloqueo entre la bomba y el objeto afectado
            if (!HasObstacleBetween(transform.position, hit.point, obstacleLayer))
            {
                Vida vidaComponent = hit.collider.GetComponent<Vida>();
                if (vidaComponent != null)
                {
                    vidaComponent.TakeDamage(damageAmount);
                }
            }
        }

        Destroy(gameObject);
    }

    private bool HasObstacleBetween(Vector3 start, Vector3 end, LayerMask obstacleLayer)
    {
        RaycastHit[] obstacleHits = Physics.RaycastAll(start, end - start, Vector3.Distance(start, end), obstacleLayer);

        return obstacleHits.Length > 0;
    }

    private IEnumerator ExplodeAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        Explode();
    }
}