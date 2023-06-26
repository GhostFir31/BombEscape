using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    [SerializeField] private GameObject menuPausa;

    private bool juegoPausado=false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(juegoPausado) {
                Reanudar();
            } else {
                Pausa();
            }

        }
    }
    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        menuPausa.SetActive(true);

    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);

    }

    public void Reiniciar()
    {
        juegoPausado = false;
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Volver()
    {
        juegoPausado = false;
        Debug.Log("Volviendo Menu");
        SceneManager.LoadScene("SampleScene");

    }
}
