using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyBird : MonoBehaviour
{
    public AudioClip FlyAudioClip, DeathAudioClip, ScoredAudioClip;
    public float RotateUpSpeed = 1, RotateDownSpeed = 1;
    public GameObject gameStartCanvas, gameOverCanvas;
    public Collider2D restartButtonGameCollider;
    public float VelocityPerJump = 3;
    public float XSpeed = 1;
    Vector3 birdRotation = Vector3.zero;

    enum birdCurDir
    {
        up, down
    }

    birdCurDir flappyYAxisTravelState;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        //handle back key in Windows Phone
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        // starting
        if (GameStateManager.GameState == GameState.Introduction)
        {
            birdFlyX();
            if (ifTriggerToStart())
            {
                flyUp();
                GameStateManager.GameState = GameState.Playing;
                gameStartCanvas.SetActive(false);
                ScoreManager.Score = 0;
            }
        }

        else if (GameStateManager.GameState == GameState.Playing)
        {
            birdFlyX();
            if (ifTriggerToStart())
            {
                flyUp();
            }

        }

        else if (GameStateManager.GameState == GameState.Dead)
        {
            Vector2 contactPoint = Vector2.zero;

            if (Input.touchCount > 0)
                contactPoint = Input.touches[0].position;
            if (Input.GetMouseButtonDown(0))
                contactPoint = Input.mousePosition;

            //check if user wants to restart the game
            if (restartButtonGameCollider == Physics2D.OverlapPoint
                (Camera.main.ScreenToWorldPoint(contactPoint)))
            {
                GameStateManager.GameState = GameState.Introduction;
                SceneManager.LoadScene(0);
            }
        }

    }


    void FixedUpdate()
    {
        //just jump up and down on intro screen
        if (GameStateManager.GameState == GameState.Introduction)
        {
            if (GetComponent<Rigidbody2D>().velocity.y < -1)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GetComponent<Rigidbody2D>().mass * 5500 * Time.deltaTime));

        }
        else if (GameStateManager.GameState == GameState.Playing || GameStateManager.GameState == GameState.Dead)
        {
            BirdRotates();
        }
    }

    bool ifTriggerToStart()
    {
        if (Input.GetButtonUp("Jump") || Input.GetMouseButtonDown(0) || 
            (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
            return true;
        else
            return false;
    }

    void birdFlyX()
    {
        transform.position += new Vector3(Time.deltaTime * XSpeed, 0, 0);
    }

    void flyUp()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, VelocityPerJump);
        GetComponent<AudioSource>().PlayOneShot(FlyAudioClip);
    }



    private void BirdRotates()
    {
        if (GetComponent<Rigidbody2D>().velocity.y > 0) flappyYAxisTravelState = birdCurDir.up;
        else flappyYAxisTravelState = birdCurDir.down;

        float degreesToAdd = 0;

        switch (flappyYAxisTravelState)
        {
            case birdCurDir.up:
                degreesToAdd = 3 * RotateUpSpeed;
                break;
            case birdCurDir.down:
                degreesToAdd = -2 * RotateDownSpeed;
                break;
            default:
                break;
        }
        //from -30  - 30
        birdRotation = new Vector3(0, 0, Mathf.Clamp(birdRotation.z + degreesToAdd, -30, 30));
        transform.eulerAngles = birdRotation;

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            //the blank
            if (col.gameObject.tag == "PipeBlankTrigger")
            {
                GetComponent<AudioSource>().PlayOneShot(ScoredAudioClip);
                ScoreManager.Score++;
                Debug.Log("score: " + ScoreManager.Score.ToString());
            }
            else if (col.gameObject.tag == "Pipe")
            {
                FlappyDies();
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            if (collision.gameObject.tag == "Floor")
            {
                FlappyDies();
            }
        }
    }


    void FlappyDies()
    {
        GameStateManager.GameState = GameState.Dead;
        gameOverCanvas.SetActive(true);
        //play the death audio
        GetComponent<AudioSource>().PlayOneShot(DeathAudioClip);
    }
}
