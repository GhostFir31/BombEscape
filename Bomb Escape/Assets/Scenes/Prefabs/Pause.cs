using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    public void Pausa()
    {
                Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);

    }

    public
}