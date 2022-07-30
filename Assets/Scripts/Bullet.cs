using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.right * speed * Time.deltaTime;

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.SetActive(false);

            Destroy(this.gameObject);
        }
    }
}
