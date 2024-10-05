using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    private float timer;
    private float maxTime = 1.3f;
    private float heightRange = 0.5f;
    [SerializeField] private GameObject pipes;
    private void Start()
    {
        SpawnPipes();
    }

    // Update is called once per frame
    private void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipes();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void SpawnPipes()
    {
        Vector3 spawnPosition = transform.position + new Vector3(-0.5f, Random.Range(-heightRange, heightRange));
        GameObject pipe = Instantiate(pipes,spawnPosition,Quaternion.identity);
        Destroy(pipe,4f);
    }
}
