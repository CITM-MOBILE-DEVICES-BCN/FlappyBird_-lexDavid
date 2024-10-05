using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 1.3f;
    private float width = 6f;
    private SpriteRenderer spriteRenderer;
    private Vector2 startSize;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startSize = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);
    }

    // Update is called once per frame
    private void Update()
    {
        spriteRenderer.size = new Vector2(spriteRenderer.size.x + speed *Time.deltaTime, spriteRenderer.size.y);

        if(spriteRenderer.size.x > width)
        {
            spriteRenderer.size = startSize;
        }
    }
}
