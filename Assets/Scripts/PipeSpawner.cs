using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeSpawner : MonoBehaviour
{

    private GameObject pipe;
    public GameObject[] pipeTypes;

    private List<int> usedValues;
    private Queue<GameObject> pipeQueue = new Queue<GameObject>();
    public float timeMin;
    public float timeMax;

    void Start()
    {
        usedValues = new List<int>();
 
        //randomly generate the pipe
        //Debug.Log("dddddddddd " + pipeTypes.Length.ToString());
        pipe = pipeTypes[Random.Range(0, pipeTypes.Length)];
        SpawnPipe();
    }

    private int UniqueRandomInt(int min, int max)
    {
        int val = Random.Range(min, max);
        while(usedValues.Contains(val))
        {
            val = Random.Range(min, max);
        }
        return val;
    }

    public void setMinTime(float delta)
    {
        if(timeMin < 1.0f)
        {
            timeMin = 1.0f;
            return;
        } 
        timeMin = timeMin - delta;
    }

    public void setMaxTime(float delta)
    {
        if(timeMax < 2.0f)
        {
            timeMax = 2.0f;
            return;
        }
        timeMax = timeMax - delta;

    }

    public void CancelGenPipes()
    {
        CancelInvoke();
    }


    void SpawnPipe()
    {
        if (pipeQueue.Count == 0)
        {
            CancelInvoke();
        }
        //Debug.Log("dddddddddd " + pipeQueue.Count.ToString());
        if (GameStateManager.GameState == GameState.Playing)
        {
            if(pipeQueue.Count > 4)
            {
                GameObject dsTroyPipe = pipeQueue.Dequeue();
                Destroy(dsTroyPipe);
            }
            int randomIdx = 0;
            int randSeed = UniqueRandomInt(1,10);
            if(randSeed >7)
                randomIdx = 1; // slant pipe
            else
                randomIdx = 0; //vertical pipe
            //Debug.Log("random number : " + randomIdx.ToString());
            GameObject newpipe;
            //random y position
            float randomY = Random.Range(-0.5f, 0.8f);
            newpipe = Instantiate(pipeTypes[randomIdx], this.transform.position + new Vector3(0, randomY, 0), Quaternion.identity) as GameObject;
            newpipe.transform.position=new Vector3( newpipe.transform.position.x, newpipe.transform.position.y,0);
            pipeQueue.Enqueue(newpipe);
        }
        // if the time is fixed, the space of two pipes will be the same
        //the difficulty will be lower
        // use the InvokeRepeating
        Invoke("SpawnPipe", Random.Range(timeMin, timeMax));
    }

}
