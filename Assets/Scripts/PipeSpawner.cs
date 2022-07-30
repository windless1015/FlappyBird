using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeSpawner : MonoBehaviour
{

    private GameObject pipe;
    public GameObject[] pipeTypes;

    public float timeMin = 1.0f;
    public float timeMax = 2.5f;

    void Start()
    {
        //randomly generate the pipe
        Debug.Log("dddddddddd " + pipeTypes.Length.ToString());
        pipe = pipeTypes[Random.Range(0, pipeTypes.Length)];
    }

    void Update()
    {

    }

    void SpawnPipe()
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            //random y position
            float randomY = Random.Range(-0.5f, 1f);
            GameObject newPipe = Instantiate(pipe, this.transform.position + new Vector3(0, randomY, 0), Quaternion.identity) as GameObject;
        }
        // if the time is fixed, the space of two pipes will be the same
        //the difficulty will be lower
        //use the InvokeRepeating
        Invoke("SpawnPipe", Random.Range(timeMin, timeMax));
    }

}
