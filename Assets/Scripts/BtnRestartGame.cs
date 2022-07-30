using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BtnRestartGame : MonoBehaviour
{
    public Button replay;

	void Start () {
		Button btn = replay.GetComponent<Button>();
		btn.onClick.AddListener(RestartGame);
	}

	// void TaskOnClick(){
	// 	Debug.Log ("You have clicked the button!");
	// }
    
    void RestartGame()
    {
        GameStateManager.GameState = GameState.Introduction;
        SceneManager.LoadScene(0);
    }
}
