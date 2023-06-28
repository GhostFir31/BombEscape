using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;  // El objetivo al que el enemigo debe acercarse
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Calcula el nuevo destino
            Vector3 targetPosition = target.position;
            agent.SetDestination(targetPosition);
        }
    }
}
