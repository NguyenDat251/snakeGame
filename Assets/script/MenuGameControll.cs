using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class MenuGameControll : MonoBehaviour {
    public GameObject bntStart;
    public GameObject bntHighScore;
    public GameObject theHighScore;
    public GameObject bntX;
    public GameObject theBoard;
    public Text txtHighScore;

    // Use this for initialization
    void Start () {
        theHighScore.SetActive(false);
        StreamReader rd = new StreamReader("HighScore.txt");
        txtHighScore.text = rd.ReadLine();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pressTheHighScore()
    {
        theHighScore.SetActive(true);
    }

    public void pressTheXButton()
    {
        theHighScore.SetActive(false);
    }

    public void pressTheStartButton()
    {
         SceneManager.LoadScene(0);
    }
}
