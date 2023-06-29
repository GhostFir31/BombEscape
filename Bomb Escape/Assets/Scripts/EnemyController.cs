using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int pointsToGive = 1;
    public PlayerControllerPersonaje playerController;

    private void Start()
    {
        // Buscar y almacenar una referencia al script del jugador
        playerController = FindObjectOfType<PlayerControllerPersonaje>();
    }

    private void OnDestroy()
    {
        // Otorgar puntos al jugador cuando el enemigo sea destruido
        if (playerController != null)
        {
            playerController.AddPoints(pointsToGive);
        }
    }
}