using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    //pipe prefab's trigger collision event
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if(collision.gameObject.name == "Bird")
            Score.score++;
    }
}
