using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelectBG : MonoBehaviour
{

	void Start () 
    {
        //generate a random seed to choose which sprite as the back ground
        // more backgrounds will be better
        int randSeed = Random.Range(0, Backgrounds.Length);
        (GetComponent<Renderer>() as SpriteRenderer).sprite = Backgrounds[randSeed];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //just set the backgrounds list from inspector
    public Sprite[] Backgrounds;
}
