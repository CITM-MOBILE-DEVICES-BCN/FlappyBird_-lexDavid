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
    public GameObject pipeSpawn;    
    public GameObject title; 
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;

        
        if (startButton != null)
        {
            startButton.onClick.AddListener(OnStartButtonClick);
        }
    }

   
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

   
    public void OnStartButtonClick()
    {
        
        if (startCanvas != null)
        {
            startButton.gameObject.SetActive(false);
            title.gameObject.SetActive(false);
            score.gameObject.SetActive(true);
            FlyMovement.rb.gravityScale = 0.65f;
            FlyMovement.isPlaying = true;
            pipeSpawn.gameObject.SetActive(true);
          
            
        }

       
    }
}

