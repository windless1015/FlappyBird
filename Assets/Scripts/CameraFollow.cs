using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	void Start () {
        cameraZ = transform.position.z;
	}

    float cameraZ;


	void Update () {
        transform.position = new Vector3(Player.position.x + 0.5f, 0, cameraZ);
       
	}

    
    public Transform Player;
}
