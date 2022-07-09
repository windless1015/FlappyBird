using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBirdStarting : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("Flap", .1f, .4f);
	}
	public Vector2 jumpForce = new Vector2(0, 250);

	void Flap()
	{

		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().AddForce(jumpForce);
	}
}
