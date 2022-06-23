using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
    public GameManager gameManager;
    public float verticalVelocity = 2.4f;
    private Rigidbody2D birdRigBody;
    // Start is called before the first frame update
    void Start()
    {
        birdRigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            birdRigBody.velocity = Vector2.up * verticalVelocity;
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }
}
