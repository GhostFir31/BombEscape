using UnityEngine;

public class DanoEnemigo : MonoBehaviour
{
    public float damageAmount = 10f; // Cantidad de daño a aplicar
    public GameObject targetObject; // Objeto al que se le hará daño

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject)
        {
            Vida vidaComponent = other.GetComponent<Vida>();

            if (vidaComponent != null)
            {
                vidaComponent.TakeDamage(damageAmount);
            }
        }
    }
}
