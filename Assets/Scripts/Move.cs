using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Move : MonoBehaviour
{
    public float speed = 1.5f;

    public GameObject[] showGames;

    public bool isCanEnemy=true;
    // Start is called before the first frame update
    void Start()
    {

        if (!isCanEnemy)
            return;

       var showIndex= Random.Range(1, 15);
        if (showIndex < showGames.Length)
        {
            showGames[showIndex].SetActive(true);
            if (showIndex < 2) {
                showGames[showIndex].transform.DOLocalMoveY(-0.46f, 2f);
            }
            else {
              
            showGames[showIndex].transform.DOLocalMoveY(0.358f, 2f);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
