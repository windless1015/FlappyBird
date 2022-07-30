using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.GameState == GameState.Dead)
            return;
    
        //if it reaches to the edge, the origi x position is 2.06, and the right corner is -2.06
        if (transform.localPosition.x < -2.06f)
        {
            transform.localPosition = new Vector3(2.06f, transform.localPosition.y, transform.localPosition.z);
        }
        float birdSpeedHorizontal = 1.0f; //this is the horizontal speed of bird
        transform.Translate(-Time.deltaTime * birdSpeedHorizontal, 0, 0);
    }
}
