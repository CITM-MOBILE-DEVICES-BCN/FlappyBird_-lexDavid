using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Añadimos esta línea para gestionar el botón

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject canvas;
    public GameObject startCanvas;
    public Button startButton; 
    public GameObject score; 
    public GameObject player; 
    public GameObject pipeSpawn;  
    public GameObject flappyUI;  
    public GameObject title; 
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;

        // Asegurarse de que el botón esté asignado y se le añada el listener
        if (startButton != null)
        {
            startButton.onClick.AddListener(OnStartButtonClick);
        }
    }

    // Función para reiniciar el juego (ya existente)
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PipeMovement.pipeSpeed = 0.65f;
        Ground.speed = 1.3f;
    }
    public void FinalScreen()
    {
        canvas.SetActive(true);
        Time.timeScale = 0f;
       
    }

    // Nuevo método para ocultar el Canvas y empezar el juego
    public void OnStartButtonClick()
    {
        // Desactivar el Canvas inicial
        if (startCanvas != null)
        {
            startButton.gameObject.SetActive(false);
            title.gameObject.SetActive(false);
            flappyUI.gameObject.SetActive(false);
            score.gameObject.SetActive(true);
            FlyMovement.rb.gravityScale = 0.65f;
            pipeSpawn.gameObject.SetActive(true);
          
            
        }

       
    }
}

