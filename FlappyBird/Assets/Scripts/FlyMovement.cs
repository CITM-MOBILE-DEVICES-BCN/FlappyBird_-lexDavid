using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    private float velocity = 1.75f;
    private float rotationSpeed = 10f;
    public static Rigidbody2D rb;
    AudioManager audioManager;
    private bool isAlive = true;
    // Start is called before the first frame update

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {

            rb.velocity = Vector2.up * velocity;
            audioManager.PlaySFX(audioManager.jump);
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        velocity = 0;
        PipeMovement.pipeSpeed = 0f;
        Ground.speed = 0f;
        Invoke("GameOver", 1.75f);
        audioManager.PlaySFX(audioManager.death);
        gameObject.GetComponent<Collider2D>().enabled = false;
        isAlive = false;

    }

    public void GameOver()
    {

        //canvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
