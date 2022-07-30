using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.5f;
    public AudioClip ScoredAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }


    

    void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;//Piranha
        if(tag == "Pipe")
        {
            Destroy(this.gameObject);
        }

        if (tag == "Piranha") 
        {
            Destroy(col.gameObject);
            GetComponent<AudioSource>().PlayOneShot(ScoredAudioClip);
            ScoreManager.Score++;
        }
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     string tag = collision.gameObject.tag;//Piranha
    //     if (tag == "Piranha") {
    //         Destroy(this.gameObject);
    //         Destroy(collision.gameObject);
    //     }
        
    // }
}
