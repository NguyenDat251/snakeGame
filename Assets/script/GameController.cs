using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour {

    //public Text point;
    //public Text endChat;
    public Button btnRestar;
    public GameObject pnlEndGame;
    public GameObject chatLoser;
    public GameObject chatWow;
    public Text ScoreEndGame;
    public Text HighScoreEndGame;

    GameObject eatFood;
    GameObject Move;
    public GameObject theBlur;
    public GameObject theScoreBoard;

    public GameObject TheEndGame;

    public bool isEndGame;
    // Use this for initialization

    void Start () {
        isEndGame = false;
        pnlEndGame.SetActive(false);
        chatLoser.SetActive(false);
        chatWow.SetActive(false);
        theBlur.SetActive(false);
        theScoreBoard.SetActive(true);
        Time.timeScale = 1;
     
        if (eatFood == null)
            eatFood = GameObject.FindGameObjectWithTag("food");
    }
	
	// Update is called once per frame
	void Update () {
      
           
    }

    public void restart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(0);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        isEndGame = true;
        Time.timeScale = 0;
        string Score = eatFood.GetComponent<SpawnFood>().getScore().text;
        string HScore = eatFood.GetComponent<SpawnFood>().textHighScore.text;
        ScoreEndGame.text = "Score\n" + Score;
        HighScoreEndGame.text = "High score\n" + HScore;

        pnlEndGame.SetActive(true);
        if (Int32.Parse(Score) < Int32.Parse(HScore))
            chatLoser.SetActive(true);
        else
        {
            chatWow.SetActive(true);
        }
        theBlur.SetActive(true);
        theScoreBoard.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(Scale(TheEndGame));
    }


    public float maxSize;
    public float growFactor;
    public float waitTime;
    

    IEnumerator Scale(GameObject a)
    {
        //Debug.Log("chay chay");
        float timer = 0;

        while (isEndGame) // this could also be a condition indicating "alive or dead"
        {
            Debug.Log("pause");
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (maxSize > a.transform.localScale.x)
            {
                timer += Time.deltaTime;
                a.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
            // reset the timer

            yield return new WaitForSeconds(waitTime);

        }
    }

}
