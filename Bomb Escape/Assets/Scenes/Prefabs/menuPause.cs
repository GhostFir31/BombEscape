using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuPause : MonoBehaviour
{

    public GameObject pauseMenu;

    private void Awake()
    {

        pauseMenu.SetActive(false);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            pauseMenu.SetActive(true);
            Time.timeScale = 0;

        }
    }

}
