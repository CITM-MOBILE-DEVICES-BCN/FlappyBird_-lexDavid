using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public static float pipeSpeed = 0.65f;
   
    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
    }
}
