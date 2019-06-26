using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private float maxYpos;
    [SerializeField]
    private float minYpos;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private GameObject pipe;

    // Start is called before the first frame update
    void Start()
    {
        //StartSpawningPipes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopSpawningPipes()
    {
        CancelInvoke("SpawnPipe");
    }

    public void StartSpawningPipes()
    {
        InvokeRepeating("SpawnPipe", 0.2f, spawnTime);
    }

    private void SpawnPipe()
    {
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(minYpos, maxYpos), 0), Quaternion.identity);
    }
}
