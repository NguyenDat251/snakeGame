using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text point;
    public Text endChat;
    public Button btnRestar;
    public GameObject pnlEndGame;
    public GameObject chatLoser;

    bool isEndGame;
    // Use this for initialization

    void Start () {
        isEndGame = false;
        pnlEndGame.SetActive(false);
        chatLoser.SetActive(false);
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (isEndGame)
        {
            //isEndGame = false;

            if (Input.GetMouseButtonDown(0))
                restart();
            
        }
	}



    public void restart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        isEndGame = true;
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        chatLoser.SetActive(true);
    }
}
