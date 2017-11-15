using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SpawnFood : MonoBehaviour {
    public GameObject foodPrefabs;
    public static bool beEaten;

    int score = 0;
    int highScore = 0;
    public Text textScore;
    public Text textHighScore;

    
    public bool isBiggerHighScore;

    public Transform borderLeft;
    public Transform borderRight;
    public Transform borderTop;
    public Transform borderBot;

    // Use this for initialization
    void Start () {
        isBiggerHighScore = false;

        StreamReader rd = new StreamReader("HighScore.txt");

        highScore = Int32.Parse(rd.ReadLine());
        textHighScore.text = "" + highScore;
        

        beEaten = false;
	}
    
    // Update is called once per frame
    void Update () {

        textScore.text = "" + score;
		if(beEaten == true)
        {
            Debug.Log("food die die die");

            score++;

            int x = (int)UnityEngine.Random.Range(borderLeft.position.x + 1f, borderRight.position.x - 1f);
            
            int z = (int)UnityEngine.Random.Range(borderBot.position.z + 1f, borderTop.position.z - 1f);
            
            transform.position = new Vector3(x, 0.5f, z);

            beEaten = false;
        }

        fixPosition();
	}

    void fixPosition()
    {
        Vector3 currentPos = this.transform.position;
        if (currentPos.x * 10 % 10 != 5 || currentPos.z * 10 % 10 != 5)
        {
            Vector3 fixPos = new Vector3();
            fixPos.x = Mathf.Floor(currentPos.x) + 0.5f;
            fixPos.y = 0.5f;
            fixPos.z = Mathf.Floor(currentPos.z) + 0.5f;
            this.transform.position = fixPos;
        }

    }

    public Text getScore()
    {
        return textScore;
    }
}
