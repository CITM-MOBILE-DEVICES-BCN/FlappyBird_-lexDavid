using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    private float velocity = 1.75f;
    private float rotationSpeed = 10f;
    public static Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * velocity;
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
        Invoke("GameOver", 1);
        
    }

    public void GameOver()
    {

        //canvas.SetActive(true);
        Time.timeScale = 0f;
    }
}