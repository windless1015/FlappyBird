using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
    public GameManager gameManager;
    public float verticalVelocity = 2.4f;
    //public Vector2 jumpForce = new Vector2(0, 300);
    private Rigidbody2D birdRigBody;
    // Start is called before the first frame update

    public GameObject bulletPerfab;
    void Start()
    {
        birdRigBody = GetComponent<Rigidbody2D>();

        //birdRigBody.velocity = Vector2.zero;
        //birdRigBody.AddForce(jumpForce);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            birdRigBody.velocity = Vector2.up * verticalVelocity;

            //birdRigBody.velocity = Vector2.zero;
            //birdRigBody.AddForce(jumpForce);

        }
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("space")) {

          var go =  GameObject.Instantiate(bulletPerfab, transform.position + new Vector3(0.3f,0,0), Quaternion.identity, null);
            
        }


        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.y < -1 * Screen.height)
        {
            gameManager.GameOver();
        }

        if (birdRigBody.velocity.y > 0)
        {
            // first is min, second is max, third is the progress proportion
            float angle1 = Mathf.Lerp(0, 25, (birdRigBody.velocity.y / 10f)) + 5.0f;
            Debug.Log("1111: " + angle1.ToString());
            transform.rotation = Quaternion.Euler(0, 0, angle1);
        }
        else
        {
            float angle = Mathf.Lerp(0, -90, (-birdRigBody.velocity.y / 30f)) - 5.0f;
            Debug.Log("222: " + angle.ToString());
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }
}
