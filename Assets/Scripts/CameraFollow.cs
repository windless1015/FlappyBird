using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform birdTransform;
    
	void Start () {
        cameraZ = transform.position.z;
	}

    float cameraZ;


	void Update () {
        transform.position = new Vector3(birdTransform.position.x + 0.5f, 0, cameraZ);
       
	}

}
