using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public enum EnemyState {Patrol, AttackPlayer, ChasePlayer};
    public EnemyState currentState;
    [SerializeField] public Sight sightSensor;
    [SerializeField] public float playerAttackDistance;

    [SerializeField] private Transform [] patrolPoints;
    private NavMeshAgent agent; 
    private int destPoint;

    private void Awake() {
        agent = GetComponent <NavMeshAgent>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         if(currentState == EnemyState.Patrol){
            Patrol();
        }
        else if(currentState == EnemyState.ChasePlayer){
            ChasePlayer();
        }
        else if(currentState == EnemyState.AttackPlayer){
            AttackPlayer();
        }    
    }

    void Patrol(){
        agent.isStopped = false;
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
            GoNextPoint();
        /* Si en su patrullaje el enemigo detecta al jugador, el enemigo procedera a perseguir el jugador*/
        if(sightSensor.detectedObject != null)
            currentState = EnemyState.ChasePlayer;

        print("Patrullando");
    }

    void GoNextPoint()
    {
        agent.destination = patrolPoints[destPoint].position;
        destPoint = (destPoint + 1) % patrolPoints.Length;
    }

    void ChasePlayer(){
        agent.isStopped = false;
        //Si estando en persecucion el jugador sale del area de vision del enemigo, el enemigo volvera a patrullaje

        if(sightSensor.detectedObject == null){
            currentState = EnemyState.Patrol;
            return;
        }

        //Si el enemigo esta a distancia de ataque, procedera a atacar al jugador

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        

        if(distanceToPlayer <= playerAttackDistance){
            currentState = EnemyState.AttackPlayer;
        }
        print("Chasing"); 

        agent.SetDestination(sightSensor.detectedObject.transform.position);
    }

    void AttackPlayer(){
        agent.isStopped = true;
        
        if(sightSensor.detectedObject == null){
            currentState = EnemyState.Patrol;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if(distanceToPlayer > playerAttackDistance * 1.1f){
            currentState = EnemyState.ChasePlayer;
        }
        print("Attacking");
        FaceTarget(sightSensor.detectedObject.transform.position);
        
    }

    private void FaceTarget(Vector3 targetPosition)
    {
        Vector3 directionToFace = Vector3.Normalize(targetPosition - transform.position);
        directionToFace.y = 0;
        transform.forward = directionToFace;
    }
}