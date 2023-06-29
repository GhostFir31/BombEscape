using UnityEngine;

public class Life : MonoBehaviour
{
    public float maxLifeAmount = 100f; // Vida máxima del objeto
    public float lifeAmount; // Vida actual del objeto

    private void Start()
    {
        lifeAmount = maxLifeAmount; // Establecer la vida inicial al valor máximo
    }

    public void TakeDamage(float damageAmount)
    {
        lifeAmount -= damageAmount; // Restar la cantidad de daño a la vida actual

        if (lifeAmount <= 0f)
        {
            Die(); // Si la vida llega a cero o menos, llamar a la función Die
        }
    }

    private void Die()
    {
        // Aquí puedes añadir cualquier lógica adicional cuando el objeto muere
        Destroy(gameObject); // Por ejemplo, destruir el objeto cuando muere
    }
}
