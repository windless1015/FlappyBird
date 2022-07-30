using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PipePiranha : MonoBehaviour
{
    public float speed = 1.5f;

    public GameObject[] piranhaList;

    //public bool isCanEnemy=true;
    // Start is called before the first frame update

    void Start()
    {


        /*
        DOLocalMoveX/DOLocalMoveY/DOLocalMoveZ(float to, float duration, bool snapping)
        Moves the target's localPosition to the given value, tweening only the chosen axis.
        snapping If TRUE the tween will smoothly snap all values to integers.
        */

        var showIndex= Random.Range(1, 16);
       showIndex = 1;

        if (showIndex < piranhaList.Length)
        {
            piranhaList[showIndex].SetActive(true);
            if (showIndex < 2) {
                piranhaList[showIndex].transform.DOLocalMoveY(-0.46f, 2f); //up
            }
            else {
            piranhaList[showIndex].transform.DOLocalMoveY(0.358f, 2f); //down

            }
            piranhaList[showIndex].layer = 0;
        }


    }

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
