
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    /*
        [SerializeField] private GameObject menuPausa;

        private bool juegoPausado = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                print("Haz presionado escape");
                if (juegoPausado)
                {
                    Reanudar();
                }
                else
                {
                    Pausa();
                }

            }

        }
        public void Pausa()
        {
            juegoPausado = true;
            Time.timeScale = 0f;
            menuPausa.SetActive(true);
            print("Haz presionado pausa");
        }

        public void Reanudar()
        {
            juegoPausado = false;
            Time.timeScale = 1f;
            menuPausa.SetActive(false);
            print("Haz presionado reanudar");
        }

        public void Reiniciar()
        {
            juegoPausado = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            print("Haz presionado reiniciar");
        }
        public void Volver()
        {
            juegoPausado = false;
            Debug.Log("Volviendo Menu");
            SceneManager.LoadScene("SampleScene");
            print("Haz presionado volver");
        }*/

    public GameObject pauseMenu;
    public Button resumeButton;
    public Button menuButton;


    private void Awake()
    {

        pauseMenu.SetActive(false);
        //resumeButton.onClick.AddListener(OnResumePressed);
        menuButton.onClick.AddListener(OnMenuPressed);

    }

    void OnMenuPressed()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");

    }

}
