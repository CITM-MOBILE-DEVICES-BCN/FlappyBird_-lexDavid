using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreUI.instance.UpdateScore();
        }
    }
}
