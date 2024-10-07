using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyMovement : MonoBehaviour
{
    public float velocity = 1.75f;
    private float rotationSpeed = 10f;
    public static Rigidbody2D rb;
    AudioManager audioManager;
    GameManager managment;
    public static bool isPlaying;
    // Start is called before the first frame update

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        managment = GameObject.FindObjectOfType<GameManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isPlaying = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isPlaying)
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
        Invoke("GameOver", 1.0f);
        StartCoroutine(PlayDeathAndFallSounds());
        gameObject.GetComponent<Collider2D>().enabled = false;
        isPlaying = false;

    }
    IEnumerator PlayDeathAndFallSounds()
    {
       
        audioManager.PlaySFX(audioManager.death);

        
        yield return new WaitForSeconds(0.5f);

        
        audioManager.PlaySFX(audioManager.fall);
    }
    public void GameOver()
    {

        managment.FinalScreen();
    }
}
